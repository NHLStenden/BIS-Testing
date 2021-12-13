DROP DATABASE IF EXISTS FakerData;

CREATE DATABASE FakerData COLLATE utf8mb4_general_ci;

USE FakerData;

# MySQL (Pure) CREATE USER 'faker'@'localhost' IDENTIFIED WITH mysql_native_password BY 'ZWGZ3hOf)Rmr(@im';
# MariaDB: CREATE USER 'faker'@'localhost' IDENTIFIED WITH mysql_native_password USING PASSWORD( 'ZWGZ3hOf)Rmr(@im');

CREATE USER IF NOT EXISTS 'faker'@'localhost' IDENTIFIED WITH mysql_native_password USING PASSWORD('ZWGZ3hOf)Rmr(@im');

GRANT ALL PRIVILEGES ON `FakerData`.* TO 'faker'@'localhost';


CREATE TABLE tbl_employee (
  id INT(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
  personeelsNr VARCHAR(12) NOT NULL,
  achternaam VARCHAR(100) NOT NULL,
  voornaam VARCHAR(100) NOT NULL,
  mail VARCHAR(255) NULL,
  geslacht CHAR(1),
  geboortedatum DATE
);
CREATE UNIQUE INDEX tbl_employee_personeelsNr ON tbl_employee (personeelsNr);

CREATE TABLE tbl_reviews (
    id INT(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    fk_idEmployee INT(11) NOT NULL,
    review LONGTEXT NOT NULL,
    CONSTRAINT fk_idEmployee FOREIGN KEY (fk_idEmployee) REFERENCES tbl_employee(id) ON UPDATE RESTRICT ON DELETE CASCADE 
);

CREATE OR REPLACE VIEW vw_Employee_reviews AS
    SELECT emp.id as idEmployee,
           emp.achternaam, 
           emp.voornaam,
           rev.review
    FROM tbl_employee emp
         LEFT JOIN tbl_reviews rev ON emp.id = rev.fk_idEmployee;

