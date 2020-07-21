-- All passwords are "abcd"
INSERT INTO [Employees] ([Name], [Hash], [DateHired], [SupervisorId], [IsAdmin]) VALUES
    (N'John', N'$2a$11$udhaTybMuvsRx9T.50yrvucbHXhp2apI.yzUYnksY9RQu2vEt3rNy', '2015-01-10', NULL, 1);
INSERT INTO [Employees] ([Name], [Hash], [DateHired], [SupervisorId], [IsAdmin]) VALUES
    (N'Jane', N'$2a$11$VxuEVMl.SIIUzNUKs.Fgz.FK0vtM3yXamOqZGKf4a9248Fv4gklJi', '2015-02-20', 1, 0);
INSERT INTO [Employees] ([Name], [Hash], [DateHired], [SupervisorId], [IsAdmin]) VALUES
    (N'Tom', N'$2a$11$RsrYIyKbO7zbsZPyZMjQnugWe/a1Vjq3lSFeW9vrfD6Dwo9tnT/Gi', '2016-06-19', 2, 0);
INSERT INTO [Employees] ([Name], [Hash], [DateHired], [SupervisorId], [IsAdmin]) VALUES
    (N'Bob', '$2a$11$Wber3w2LytDjcR0uH.89xeQq0x9o7HIbgqSy6JStNQTfXOJ.UxXZW', '2016-06-20', 2, 0);
