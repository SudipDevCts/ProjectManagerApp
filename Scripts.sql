CREATE TABLE ParentTask (
  Parent_ID    INTEGER PRIMARY KEY Identity(1,1), 
  Parent_Task  varchar
);

CREATE TABLE Project (
  Project_ID    INTEGER PRIMARY KEY Identity(1,1), 
  Project  varchar(400) Not Null,
  StartDate DateTime,
  EndDate DateTime,
  [Priority] Integer
);

CREATE TABLE Task (
  Task_ID     INTEGER PRIMARY KEY Identity(1,1), 
  Task   varchar(400), 
  Status   varchar(400), 
  Priority   INTEGER,
  Parent_ID INTEGER,
  Project_ID INTEGER,
  Start_Date DateTime,
  End_Date DateTime,
  FOREIGN KEY(Parent_ID) REFERENCES ParentTask(Parent_ID),
  FOREIGN KEY(Project_ID) REFERENCES Project(Project_ID),
);

CREATE TABLE Users  (
  [User_ID]     INTEGER PRIMARY KEY Identity(1,1), 
  FirstName   varchar(400), 
  LastName   varchar(400), 
  Employee_ID   INTEGER,
  Task_ID INTEGER,
  Project_ID INTEGER,
  FOREIGN KEY(Task_ID) REFERENCES Task(Task_ID),
  FOREIGN KEY(Project_ID) REFERENCES Project(Project_ID),
);



