using ConsoleApp23;



var connectionString = "Data Source=WINDOWS-2P363HE;Initial Catalog=Dapper;Integrated Security=True;Connect Timeout=30;Encrypt=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
var teacherRepo = new TeacherRepository(connectionString);

var newTeacher = new Teacher { Name = "Rubab", Subject = "Matematika", Email = "rb013@gmail.com", Phone = "077-777-77-77" };
teacherRepo.Insert(newTeacher);

var teacher = teacherRepo.GetById(1);

var allTeachers = teacherRepo.GetAll();

teacher.Name = "Rubus";
teacherRepo.Update(teacher);

teacherRepo.Delete(1);
