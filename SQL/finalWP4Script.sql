﻿USE MASTER;
GO
DROP DATABASE IF EXISTS socialMedia;
GO
CREATE DATABASE socialMedia;
GO

USE socialMedia;

CREATE TABLE Users (
	ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	username VARCHAR(40) NOT NULL,
	password VARCHAR(40) NOT NULL,
	email VARCHAR(50) NOT NULL,
	firstName VARCHAR(20),
	lastName VARCHAR(20),
	createdAt DATETIME NOT NULL
);

CREATE TABLE Followers (
	userID INT NOT NULL,
	followerUserID INT NOT NULL,
	followedAt DATETIME NOT NULL
);

CREATE TABLE Posts (
	ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	userID INT NOT NULL,
	post VARCHAR(200) NOT NULL,
	likes INT,
	createdAt DATETIME NOT NULL
);

CREATE TABLE Comments (
	ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	userID INT NOT NULL,
	postID INT NOT NULL,
	comment VARCHAR(200) NOT NULL,
	likes INT,
	createdAt DATETIME NOT NULL
);

ALTER TABLE Followers ADD FOREIGN KEY (userID) references Users(ID);
ALTER TABLE Posts ADD FOREIGN KEY (userID) references Users(ID);
ALTER TABLE Comments ADD FOREIGN KEY (userID) references Users(ID);
ALTER TABLE Comments ADD FOREIGN KEY (postID) references Posts(ID);
