Create procedure DummyData
as
INSERT INTO UserInfos VALUES ('Lars','lars3768','https://i.imgur.com/ciVNs.gif',1234,10,DATETIME2FROMPARTS(2018,10,25,00,00,00,0000,000))
INSERT INTO Posts VALUES ('Velkommen til det nye �r!','Lorem [i]ipsum[/i] blah blah','src/img/303-dairyfree-banana-pancakes-LH-76e8c7fb-fd90-4ddb-bce9-aa615ce9fde2-0-1400x919.jpg',DATETIME2FROMPARTS(2018,10,25,00,00,00,0000,000),1)
INSERT INTO Posts VALUES ('Velkommen til det nye �r!','Lorem [i]ipsum[/i] blah blah','src/img/B76CD657-9A91-48F3-8D1B-F076878C4401__1445432764_86.82.108.171.jpg',DATETIME2FROMPARTS(2018,10,25,00,00,00,0000,000),1)
INSERT INTO Posts VALUES ('Velkommen til det nye �r!','Lorem [i]ipsum[/i] blah blah','src/img/chilli-sin-carne.jpg',DATETIME2FROMPARTS(2018,10,25,00,00,00,0000,000),1)
INSERT INTO Comments VALUES (1,1,'Lorem [i]ipsum[/i] blah blah',DATETIME2FROMPARTS(2018,10,25,00,00,00,0000,000))