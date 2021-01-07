Create DATABASE UniManagement;
Use UniManagement;
CREATE TABLE Semester (
  SemesterID INTEGER NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [Year] INTEGER  NOT NULL,
  PRIMARY KEY(SemesterID)
);

CREATE TABLE Department (
  DepartmentID INTEGER  NOT NULL,
  Name VARCHAR(255) NULL,
  ContactNo VARCHAR(255) NULL,
  PRIMARY KEY(DepartmentID)
);

CREATE TABLE Designation (
  DesignationID INTEGER NOT NULL,
  PositionTitle VARCHAR(255) NOT NULL,
  PRIMARY KEY(DesignationID)
);

CREATE TABLE [Address] (
  AddressID INTEGER NOT NULL,
  HouseNo VARCHAR(255) NOT NULL,
  StreetNo VARCHAR(255) NOT NULL,
  ZIPCode INTEGER  NOT NULL,
  City VARCHAR(255) NOT NULL,
  PRIMARY KEY(AddressID)
);

CREATE TABLE Student (
  StudentID INTEGER NOT NULL ,
  Address_AddressID INTEGER  NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  PhoneNo VARCHAR(255) NULL,
  Gender VARCHAR(255) NOT NULL,
  DOB DATE NOT NULL,
  CGPA FLOAT  NULL,
  PRIMARY KEY(StudentID),
  FOREIGN KEY(Address_AddressID)
    REFERENCES Address(AddressID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Faculty (
  FacultyID INTEGER  NOT NULL,
  Address_AddressID INTEGER  NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  PhoneNo VARCHAR(255) NOT NULL,
  Gender VARCHAR(255) NOT NULL,
  DOB DATE NOT NULL,
  Salary INTEGER  NOT NULL,
  PRIMARY KEY(FacultyID),
  FOREIGN KEY(Address_AddressID)
    REFERENCES Address(AddressID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Course (
  CourseID VARCHAR(255)  NOT NULL,
  Department_DepartmentID INTEGER  NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [Description] VARCHAR(255) NULL,
  [Credit Hours] INTEGER  NOT NULL,
  PRIMARY KEY(CourseID),
  FOREIGN KEY(Department_DepartmentID)
    REFERENCES Department(DepartmentID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE CourseOffering (
  CourseOfferingID INTEGER  NOT NULL ,
  Semester_SemesterID INTEGER  NOT NULL,
  Course_CourseID VARCHAR(255)  NOT NULL,
  PRIMARY KEY(CourseOfferingID),
  FOREIGN KEY(Course_CourseID)
    REFERENCES Course(CourseID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Semester_SemesterID)
    REFERENCES Semester(SemesterID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Student_Semester_Enrolment (
  Student_StudentID INTEGER  NOT NULL,
  Semester_SemesterID INTEGER  NOT NULL,
  SGPA FLOAT NULL,
  Credits FLOAT NOT NULL,
  PRIMARY KEY(Student_StudentID, Semester_SemesterID),
  FOREIGN KEY(Student_StudentID)
    REFERENCES Student(StudentID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Semester_SemesterID)
    REFERENCES Semester(SemesterID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Student_Department (
  Student_StudentID INTEGER  NOT NULL,
  Department_DepartmentID INTEGER  NOT NULL,
  IsMajorDept BIT NOT NULL,
  PRIMARY KEY(Student_StudentID, Department_DepartmentID),
  FOREIGN KEY(Student_StudentID)
    REFERENCES Student(StudentID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Department_DepartmentID)
    REFERENCES Department(DepartmentID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Course_Prereq (
  Course_CourseID VARCHAR(255)  NOT NULL,
  Course_PreReqID VARCHAR(255) NOT NULL,
  PRIMARY KEY(Course_CourseID, Course_PreReqID),
  FOREIGN KEY(Course_CourseID)
    REFERENCES Course(CourseID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Course_PreReqID)
    REFERENCES Course(CourseID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Faculty_Department (
  Faculty_FacultyID INTEGER  NOT NULL,
  Department_DepartmentID INTEGER  NOT NULL,
  IsMainDept BIT NULL,
  PRIMARY KEY(Faculty_FacultyID, Department_DepartmentID),
  FOREIGN KEY(Faculty_FacultyID)
    REFERENCES Faculty(FacultyID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Department_DepartmentID)
    REFERENCES Department(DepartmentID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE CourseSection (
  CourseSectionID INTEGER  NOT NULL ,
  Faculty_FacultyID INTEGER  NOT NULL,
  CourseOffering_CourseOfferingID INTEGER  NOT NULL,
  ClassCap INTEGER NOT NULL,
  NoStudents INTEGER NOT NULL,
  PRIMARY KEY(CourseSectionID),
  FOREIGN KEY(CourseOffering_CourseOfferingID)
    REFERENCES CourseOffering(CourseOfferingID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Faculty_FacultyID)
    REFERENCES Faculty(FacultyID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);

CREATE TABLE Faculty_Designation (
  Faculty_FacultyID INTEGER  NOT NULL,
  Designation_DesignationID INTEGER  NOT NULL,
  DateStart DATE NOT NULL,
  DateEnd DATE NOT NULL,
  PRIMARY KEY(Faculty_FacultyID, Designation_DesignationID),
  FOREIGN KEY(Faculty_FacultyID)
    REFERENCES Faculty(FacultyID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(Designation_DesignationID)
    REFERENCES Designation(DesignationID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION
);


CREATE TABLE Student_Course_Enrolment (
  Student_StudentID INTEGER  NOT NULL,
  CourseSection_CourseSectionID INTEGER  NOT NULL,
  GPA VARCHAR(255) NULL,
  PRIMARY KEY(Student_StudentID, CourseSection_CourseSectionID),
  FOREIGN KEY(Student_StudentID)
    REFERENCES Student(StudentID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
  FOREIGN KEY(CourseSection_CourseSectionID)
    REFERENCES CourseSection(CourseSectionID)
      ON DELETE NO ACTION
      ON UPDATE NO ACTION,
);

