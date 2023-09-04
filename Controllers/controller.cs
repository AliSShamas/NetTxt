 using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[Controller]")]
public class DataController : ControllerBase
{
    private static  IConfiguration _config = null ;
    private string _data_folder = string.Empty;
    public DataController(IConfiguration config)

    {

       _config = config;
       _data_folder = _config["DATA_FOLDER"];
    }
    [HttpGet]
    [Route("GetStudent")]
    public Student GetSingleStudent()
    {
        Student s = new Student();
        s.Id = 555;
        s.Name = "Lila";
        return s;
    }
    [HttpGet]
    [Route("GetAllStudents")]

    public List<Student> GetAllStudents()
    {
        List<Student> _List = new List<Student>();
        string[] files = System.IO.Directory.GetFiles(_data_folder);
        foreach (var item in files)
        {
            var content = System.IO.File.ReadAllText(item);
            string[] parts = content.Split(",");
            Student s = new Student();
            s.Id = Convert.ToInt16(parts[0]);
            s.Name = parts[1];
            _List.Add(s);

        }

        return _List;
    }
    [HttpPost]
    [Route("CreateStudent")]
    public void AddStudent(Student input)
    {
        string content = $"{input.Id},{input.Name}";
        string FilePath =@$"{_data_folder}\{ input.Id}.txt";
        System.IO.File.WriteAllText(FilePath, content);
    }
    [HttpDelete]
    [Route("RemoveStudent")]
    public void DeleteStudent(Params_Delete_Student i)
    {
        string filePath = @$"{_data_folder}\{i.Id}.txt";
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);       
        }

    }
}

