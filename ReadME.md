# 1. Run Project
```
  cd api
  dotnet run
```
# 2. Test Project
```
  dotnet test
```
# 3. Project Structure
## 1) Controller
It has three API handlers:
> `POST /Api/teacher`
 - This is to add to teacher object to the Classroom Service.
 > `POST /Api/student`
 - This is to add to student object to the Classroom Service.
 > `GET /Api/roster`
 - This is to get ``(teacher, student[])``.
## 2) Domain
### (1) Classroom
It has `Teacher` object and list of `Student` objects.
### (2) Student
It has `FirstName/LastName` of the student.
### (3) Teacher
It has `FirstName/LastName` of the Teacher.
## 3) Service
### (1) Classroom Service
This is a `Singleton` instance that holds data on the backend. If we use database, it doesn't need to be Singleton.
`
# 4. Resource

You can check the API here: http://localhost:5000/swagger/index.html