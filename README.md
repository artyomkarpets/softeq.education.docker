# Information

## Project structure 

 - src - source code of backend microservices
 
 - postman - postman collection to test api 

## Source code 

 - Softeq.Education.TrialsSystem - main solution file that contains all projects
 
 ![image](https://user-images.githubusercontent.com/110222378/189868123-06f57fa4-b037-4caa-b5d0-9f254969c356.png)
 
 - docker-compose.yml (docker-compose.override.yml) - docker-compose file to start microservice
 
 ## Start project
 
 Apply scripts for identity server  
 
 1. Instal mongoshell last version: [mongosh](https://www.mongodb.com/docs/mongodb-shell/install/)
 
 2. To add all resources for IdentityService you need start only mongo db
 
 ```
 docker-compose up mongo  
 
 ```
 3. find the file applyScripts.bat and run it from CMD(Command Prompt not PowerShell) 
 
 ```
 applyScripts.bat "C:\Projects\L&D\docker\src\UsersManagement" localhost:27017
 
 ```
  - the first argument is the path to the folder to project  on your pc
  - the second argument connection string without mongodb://

this script find all files wit initdb postfix in all children folder and apply them to your db

4. Or you can apply scripts to db via studio 3t or MongoCompass yourself:
   - find scripts src\UsersManagement\TrialsSystem.IdentityService\TrialsSystem.IdentityService.InitialData\CreateScripts
   - apply commnd in studio 3t or MongoCompass 
   ![image](https://user-images.githubusercontent.com/110222378/192442637-93b34588-64ae-4c2a-817f-f0858cd70e99.png)
   ![image](https://user-images.githubusercontent.com/110222378/192443039-bb7b1cae-01f5-4a7d-8a5d-44ca16c096de.png)

5. Check DB

![image](https://user-images.githubusercontent.com/110222378/192444270-0c0f2b0e-18b9-4250-ae4a-0839d9771c24.png)

   
For start user service you need to apply migration to SqlServer  
1. Start sql server

```
 docker-compose up sqlserver -d
 
```
2. Create TS_Users database

![image](https://user-images.githubusercontent.com/110222378/192443790-3f7fca6a-3da0-4489-9c38-719b0e31a581.png)

2. Open TrialSystem.UsersService.sln

3. Run command  Update-Database

![image](https://user-images.githubusercontent.com/110222378/192443974-b88555f3-ce3f-4682-9541-38a8c65e61be.png)

4. Check DB 

![image](https://user-images.githubusercontent.com/110222378/192444097-d7d8515b-743f-487a-93fe-890043ccadc5.png)

