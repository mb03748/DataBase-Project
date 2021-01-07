USE UniManagement;

INSERT INTO Semester VALUES(1,'Fall Semester',2014);
INSERT INTO Semester VALUES(2,'Spring Semester',2014);
INSERT INTO Semester VALUES(3,'Summer Semester',2014);
INSERT INTO Semester VALUES(4,'Fall Semester',2015);
INSERT INTO Semester VALUES(5,'Spring Semester',2015);
INSERT INTO Semester VALUES(6,'Summer Semester',2015);
INSERT INTO Semester VALUES(7,'Fall Semester',2016);
INSERT INTO Semester VALUES(8,'Spring Semester',2016);
INSERT INTO Semester VALUES(9,'Summer Semester',2016);

INSERT INTO Department VALUES(121, 'Computer Science', '(+92) 315 2166067');
INSERT INTO Department VALUES(122, 'Electrical Engineering', '(+92) 312 7625892');
INSERT INTO Department VALUES(123, 'Computer Engineering', '(+92) 315 6872910');
INSERT INTO Department VALUES(124, 'Social Development and Policy', '(+92) 345 0962812');
INSERT INTO Department VALUES(125, 'Communication & Design', '(+92) 315 2166822');
INSERT INTO Department VALUES(126, 'CLS', '(+92) 315 2421625');
INSERT INTO Department VALUES(127, 'Integrated Sciences & Mathematics', '(+92) 315 2421625');

INSERT INTO Designation VALUES(244, 'Dean of Faculty');
INSERT INTO Designation VALUES(245, 'Assistant Professor');
INSERT INTO Designation VALUES(246, 'Lecturer');
INSERT INTO Designation VALUES(247, 'Director');

INSERT INTO [Address] VALUES (81,'House 421','Karsaz','75950','Karachi');
INSERT INTO [Address] VALUES (82,'House 422','Karsaz','75950','Karachi');
INSERT INTO [Address] VALUES (83,'House 423','Karsaz','75950','Karachi');
INSERT INTO [Address] VALUES (84,'House 424','Karsaz','75950','Karachi');
INSERT INTO [Address] VALUES (85,'Faculty Housing','Dastageer','75950','Karachi');
INSERT INTO [Address] VALUES (86,'ABC House','XYZ Street','98100','Karachi');
INSERT INTO [Address] VALUES (87,'Sunrise Apartments','FB Area','75950','Karachi');

INSERT INTO Student VALUES(2945,81,'Osama Yousuf','(+92) 315 2166067','M','10-26-1998','3.96');
INSERT INTO Student VALUES(2946,81,'Areeb Yousuf','(+92) 315 2166068','M','10-26-1995','3.86');
INSERT INTO Student VALUES(3232,82,'Sami Murtuza','(+92) 321 5211223','M','5-15-1994','3.7');

INSERT INTO Faculty VALUES(200,85,'Waqar Saleem','(+92) 315 2621352','M','2-9-1985','50000');
INSERT INTO Faculty VALUES(201,85,'Shahid Hussain','(+92) 345 2765215','M','2-9-1988','60000');
INSERT INTO Faculty VALUES(202,85,'Tariq Mumtaz','(+92) 345 2765215','M','6-10-1988','60000');
INSERT INTO Faculty VALUES(203,85,'Basit Memon','(+92) 345 2765215','M','5-7-1981','60000');
INSERT INTO Faculty VALUES(204,85,'Anzar Khaliq','(+92) 345 2765215','M','6-9-1982','60000');
INSERT INTO Faculty VALUES(205,85,'Yousuf Kerai','(+92) 345 2765215','M','2-10-1983','60000');
INSERT INTO Faculty VALUES(206,85,'Taj Khan','(+92) 345 2765215','M','3-12-1984','60000');
INSERT INTO Faculty VALUES(207,85,'Noman Naqvi','(+92) 332 2765864','M','2-1-1970','80000');
INSERT INTO Faculty VALUES(208,85,'Noman Baig','(+92) 345 2765215','M','5-11-1982','60000');
INSERT INTO Faculty VALUES(209,85,'Muqeem Khan','(+92) 345 2765215','M','7-9-1986','60000');
INSERT INTO Faculty VALUES(210,85,'Musabbir Majeed','(+92) 345 2765215','M','3-10-1984','60000');
INSERT INTO Faculty VALUES(211,85,'Rahma Mian','(+92) 345 2765215','F','4-5-1982','60000');
INSERT INTO Faculty VALUES(212,85,'Sabyn Javeri','(+92) 345 2765215','F','12-1-1983','60000');

INSERT INTO Course VALUES('CS 412',121,'Algorithms','Enter Description Here',3);
INSERT INTO Course VALUES('CS 355',121,'Databases','Enter Description Here',4);
INSERT INTO Course VALUES('CORE 111',121,'Logical Problem Solving','Enter Description Here',4);
INSERT INTO Course VALUES('EE 111',122,'Electric Circuit Analysis','Enter Description Here',4);
INSERT INTO Course VALUES('EE 211',122,'Basic Electronics','Enter Description Here',4);
INSERT INTO Course VALUES('PHY 102',122,'Electricity and Magnetism','Enter Description Here',3);
INSERT INTO Course VALUES('CS 232',123,'Operating Systems','Enter Description Here',4);
INSERT INTO Course VALUES('CS 371',123,'Computer Architecture','Enter Description Here',4);
INSERT INTO Course VALUES('CS 421',123,'Compiler Construction','Enter Description Here',4);
INSERT INTO Course VALUES('SDP 101',124,'Development & Social Change','Enter Description Here',3);
INSERT INTO Course VALUES('SDP 300',124,'Introduction to Health Policy','Enter Description Here',4);
INSERT INTO Course VALUES('SDP 223',124,'Punjabi Rachna','Enter Description Here',4);
INSERT INTO Course VALUES('CND 100',125,'3D Animation','Enter Description Here',4);
INSERT INTO Course VALUES('CND 102',125,'Introduction to Photography','Enter Description Here',4);
INSERT INTO Course VALUES('SDP 204',125,'Introduction to Illustration','Enter Description Here',4);
INSERT INTO Course VALUES('CLS 101',126,'World Politics','Enter Description Here',2);

-- Spring '16 has a semester id of 8
INSERT INTO CourseOffering VALUES(1,8,'CS 412');
INSERT INTO CourseOffering VALUES(2,8,'CS 355');
INSERT INTO CourseOffering VALUES(3,8,'CORE 111');
INSERT INTO CourseOffering VALUES(4,8,'EE 111');
INSERT INTO CourseOffering VALUES(5,8,'EE 211');
INSERT INTO CourseOffering VALUES(6,8,'PHY 102');
INSERT INTO CourseOffering VALUES(7,8,'CS 232');
INSERT INTO CourseOffering VALUES(8,8,'CS 371');
INSERT INTO CourseOffering VALUES(9,8,'CS 421');
INSERT INTO CourseOffering VALUES(10,8,'SDP 101');
INSERT INTO CourseOffering VALUES(11,8,'SDP 300');
INSERT INTO CourseOffering VALUES(12,8,'SDP 223');
INSERT INTO CourseOffering VALUES(13,8,'CND 100');
INSERT INTO CourseOffering VALUES(14,8,'CND 102');
INSERT INTO CourseOffering VALUES(15,8,'SDP 204');
INSERT INTO CourseOffering VALUES(16,8,'CLS 101');

INSERT INTO Student_Semester_Enrolment VALUES(2945,8,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2945,7,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2945,6,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2945,5,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2945,4,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2945,3,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2945,2,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2945,1,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2946,8,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2946,7,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2946,6,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2946,5,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2946,4,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2946,3,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2946,2,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(2946,1,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(3232,8,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(3232,7,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(3232,6,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(3232,5,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(3232,4,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(3232,3,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(3232,2,NULL,0);
INSERT INTO Student_Semester_Enrolment VALUES(3232,1,NULL,0);

INSERT INTO Student_Department VALUES(2945,121,1);
INSERT INTO Student_Department VALUES(2945,125,0);
INSERT INTO Student_Department VALUES(2946,124,1);
INSERT INTO Student_Department VALUES(2946,122,0);
INSERT INTO Student_Department VALUES(3232,122,1);

INSERT INTO Course_Prereq VALUES('CS 232','CORE 111');
INSERT INTO Course_Prereq VALUES('CS 371','CS 232');
INSERT INTO Course_Prereq VALUES('CND 100','SDP 204');
INSERT INTO Course_Prereq VALUES('CND 100','CND 102');

INSERT INTO Faculty_Department VALUES (200,121,1);
INSERT INTO Faculty_Department VALUES (200,123,0);
INSERT INTO Faculty_Department VALUES (201,121,1);
INSERT INTO Faculty_Department VALUES (201,123,0);
INSERT INTO Faculty_Department VALUES (202,122,1);
INSERT INTO Faculty_Department VALUES (203,122,1);
INSERT INTO Faculty_Department VALUES (204,127,1);
INSERT INTO Faculty_Department VALUES (205,127,1);
INSERT INTO Faculty_Department VALUES (206,123,1);
INSERT INTO Faculty_Department VALUES (206,121,0);
INSERT INTO Faculty_Department VALUES (207,126,1);
INSERT INTO Faculty_Department VALUES (208,124,1);
INSERT INTO Faculty_Department VALUES (209,125,1);
INSERT INTO Faculty_Department VALUES (210,127,1);
INSERT INTO Faculty_Department VALUES (210,121,0);
INSERT INTO Faculty_Department VALUES (211,125,1);
INSERT INTO Faculty_Department VALUES (212,124,1);

INSERT INTO CourseSection VALUES(1,200,1,40,0);
INSERT INTO CourseSection VALUES(2,201,1,40,0);
INSERT INTO CourseSection VALUES(4,200,2,40,0);
INSERT INTO CourseSection VALUES(5,200,2,40,0);

INSERT INTO Faculty_Designation VALUES(200,247,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(200,245,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(201,247,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(202,246,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(203,246,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(204,246,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(205,246,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(206,246,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(207,246,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(208,246,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(209,246,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(210,246,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(211,246,'1-1-2014','1-1-2019');
INSERT INTO Faculty_Designation VALUES(212,246,'1-1-2014','1-1-2019');
