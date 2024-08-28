SET IDENTITY_INSERT Employees ON;
INSERT INTO Employees (EmployeeId, FirstName, LastName, Position, ManagerId)
VALUES
    (1,'Bill', 'Gates', 'CEO', NULL),
    (2,'Steve', 'Jobs', 'COO', 1),
    (3,'Satya', 'Nadella', 'CFO', 1),
    (4,'Sundar', 'Pichai', 'CTO', 1),

    (5,'John', 'Doe', 'Software Developer', 3),
    (6,'Daniel', 'Anderson', 'Backend Developer', 3),
    (7,'Olivia', 'Thomas', 'Frontend Developer', 3),
    (8,'Emily', 'Brown', 'QA Engineer', 3),
    (9,'Chris', 'Davis', 'DevOps Engineer', 3),
    (10,'Matthew', 'Harris', 'Technical Support Engineer', 4),
    (11,'James', 'Jackson', 'Systems Architect', 3),

    (12,'Jane', 'Smith', 'Project Manager', 2),
    (13,'Sophia', 'White', 'Business Analyst', 12),

    (14,'Sarah', 'Wilson', 'UI/UX Designer', 2),

    (15,'Isabella', 'Martin', 'Network Engineer', 2),
    (16,'Andrew', 'Thompson', 'Security Specialist', 2),

    (17,'David', 'Miller', 'Database Administrator', 3);