-- This class is not intended to run (copied from MariaDb) --  (query from 6.2 is below)

---- There was no mention of Id in the description, so I assumed that there should be one,
---- since a composite key {name, surname, gender, class} sometimes may not be unique (for example when class has
---- 2 students with the same name). I also assumed that teacher does not teach the whole class (as it usually is),
---- or we would have to create a seperate table for class and make a FK teacherId there.

---- Task 6.1 - Create tables pupil and teacher
--CREATE TABLE `pupil` (
--    `Id` INT(11) UNSIGNED NOT NULL,
--    `Name` VARCHAR(25) NOT NULL,
--    `Surname` VARCHAR(50) NOT NULL,
--    `Gender` ENUM('M','F') NOT NULL,
--    `Class` TINYINT(3) UNSIGNED NOT NULL,
--    PRIMARY KEY (`Id`)
--);

--CREATE TABLE `teacher` (
--    `Id` INT(11) UNSIGNED NOT NULL,
--    `Name` VARCHAR(25),
--    `Surname` VARCHAR(75),
--    `Gender` ENUM('M','F'),
--    `Subject` VARCHAR(50),
--    PRIMARY KEY (`Id`)
--);

---- joined table for many-to-many relationship
--CREATE TABLE `teaching` (
--	`pupilId` INT(11) UNSIGNED NOT NULL,
--	`teacherId` INT(11) UNSIGNED NOT NULL,
--	INDEX `FK__pupil` (`pupilId`) USING BTREE,
--	INDEX `FK__teacher` (`teacherId`) USING BTREE,
--	CONSTRAINT `FK__pupil` FOREIGN KEY (`pupilId`) REFERENCES `pupil` (`Id`) ON UPDATE NO ACTION ON DELETE NO ACTION,
--	CONSTRAINT `FK__teacher` FOREIGN KEY (`teacherId`) REFERENCES `teacher` (`Id`) ON UPDATE NO ACTION ON DELETE NO ACTION
--);

---- Task 6.2 - Query to return all teachers who teach a student named 'Giorgi'
--SELECT DISTINCT t.*
--FROM teacher t INNER JOIN teaching ts ON t.Id = ts.teacherId
--INNER JOIN pupil p ON p.Id = ts.pupilId
--WHERE p.Name = "გიორგი";


