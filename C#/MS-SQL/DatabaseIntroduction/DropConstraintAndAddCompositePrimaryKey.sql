ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC077381B59A;

ALTER TABLE Users
ADD PRIMARY KEY(Id, Username);