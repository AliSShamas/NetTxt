# NetTxt
git clone the repositry
dotnet build the app ( the app is equiped with a appsettings.json file that specifies the location of the txt files)
dotnet run the app
open the browser on the given url in  the cmd example:http://localhost:5118 add /api/Data/GetStudent to get 1 student ,or add /api/Data/GetAllStudents to get all students
(data is being read from txt files in data folder to add a txt file or delete a txt file you need to do the following)
to add go to postman and set the method to post add /api/Data/CreateStudent and set the id and name a txt file will be created (using id as name)
to delete a user add /api/Data/RemoveStudent and let the method be a DELETE method and enter the id ,txt file will be deleted
