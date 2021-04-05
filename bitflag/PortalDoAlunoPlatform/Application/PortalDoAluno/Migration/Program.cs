using ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Migration
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext.ApplicationDbContext>();
            dbContextOptionsBuilder.UseSqlServer("Server=bitflag.systems;Database=PortalDoAluno_Dev;User Id=PortalDoAluno;Password=Trocar123!;MultipleActiveResultSets=true;");
            var context = new ApplicationDbContext.ApplicationDbContext(dbContextOptionsBuilder.Options);

            if (1 == 1)
            {
                #region [Students]
                using (var mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection("Server=192.185.216.154;Database=ibrat521_bdados2010;Uid=ibrat521_bdados;Pwd=@Intensivy1314;"))
                {
                    await mySqlConnection.OpenAsync();
                    using (var mySqlCommand = new MySqlCommand("SELECT * FROM alunos;", mySqlConnection))
                    {
                        using (var reader = await mySqlCommand.ExecuteReaderAsync())
                        {
                            var students = new List<ApplicationDbContext.Student>();
                            try
                            {
                                while (await reader.ReadAsync())
                                {
                                    var student = new ApplicationDbContext.Student();
                                    student.StudentId = (int)reader["cod"];
                                    student.Name = (string)reader["nome"];
                                    student.PhotoFileName = reader["foto"] == DBNull.Value ? null : ((string)reader["foto"]).Replace("fotos/", "");
                                    student.CPF = reader["cpf"] == DBNull.Value ? null : (string)reader["cpf"];
                                    student.RG = reader["rg"] == DBNull.Value ? null : (string)reader["rg"];
                                    if (reader["dtnasc_ano"] != DBNull.Value && reader["dtnasc_mes"] != DBNull.Value && reader["dtnasc_dia"] != DBNull.Value)
                                    {
                                        int ano = 0, mes = 0, dia = 0;
                                        if (int.TryParse((string)reader["dtnasc_ano"], out ano) && int.TryParse((string)reader["dtnasc_mes"], out mes) && int.TryParse((string)reader["dtnasc_dia"], out dia))
                                        {
                                            if (ano < 100) ano += 1900;
                                            if (mes > 12) mes = 12;

                                            try
                                            {
                                                student.BirthDate = new DateTime(ano, mes, dia);

                                            }
                                            catch (Exception dateException)
                                            {
                                                dateException.ToString();
                                            }
                                        }
                                    }
                                    student.Gender = reader["sexo"] == DBNull.Value ? null : (string)reader["sexo"];
                                    student.Email = reader["email"] == DBNull.Value ? null : (string)reader["email"];
                                    if (reader["ddd_telefone"] != DBNull.Value && reader["telefone"] != DBNull.Value)
                                        student.PhoneNumber = $"{(string)reader["ddd_telefone"]}{(string)reader["telefone"]}";
                                    if (reader["ddd_celular"] != DBNull.Value && reader["celular"] != DBNull.Value)
                                        student.CellPhone = $"{(string)reader["ddd_celular"]}{(string)reader["celular"]}";
                                    student.Profession = reader["profissao"] == DBNull.Value ? null : (string)reader["profissao"];
                                    student.CouncilDocumentNumber = reader["carteira"] == DBNull.Value ? null : (string)reader["carteira"];
                                    student.Zipcode = reader["cep"] == DBNull.Value ? null : (string)reader["cep"];
                                    student.Address = reader["endereco"] == DBNull.Value ? null : (string)reader["endereco"];
                                    if (!string.IsNullOrWhiteSpace(student.Address))
                                    {
                                        var _address = student.Address.Split(',');
                                        if (_address.Length > 0)
                                        {
                                            student.Number = student.Address.Replace(_address[0] + ",", string.Empty).Trim();
                                            student.Address = _address[0];

                                        }
                                    }
                                    //studentInfoViewModel.Number = reader["XXX"] == DBNull.Value ? null : (object)reader["XXX"];
                                    //studentInfoViewModel.Complement = reader["XXX"] == DBNull.Value ? null : (object)reader["XXX"];
                                    student.Neighborhood = reader["bairro"] == DBNull.Value ? null : (string)reader["bairro"];
                                    student.State = reader["estado"] == DBNull.Value ? null : (string)reader["estado"];
                                    student.City = reader["cidade"] == DBNull.Value ? null : (string)reader["cidade"];
                                    if (reader["inicio_ano"] != DBNull.Value && reader["inicio_mes"] != DBNull.Value)
                                    {
                                        int ano = 0, mes = 0, dia = 0;
                                        if (int.TryParse((string)reader["inicio_ano"], out ano) && int.TryParse((string)reader["inicio_mes"], out mes))
                                        {
                                            if (ano < 100) ano += 1900;
                                            if (mes > 12) mes = 12;

                                            try
                                            {
                                                student.StartDate = new DateTime(ano, mes, 1);
                                            }
                                            catch (Exception dateException)
                                            {
                                                dateException.ToString();
                                            }
                                        }
                                    }
                                    if (reader["termino_ano"] != DBNull.Value && reader["termino_mes"] != DBNull.Value)
                                    {
                                        int ano = 0, mes = 0, dia = 0;
                                        if (int.TryParse((string)reader["termino_ano"], out ano) && int.TryParse((string)reader["termino_mes"], out mes))
                                        {
                                            if (ano < 100) ano += 1900;
                                            if (mes > 12) mes = 12;

                                            try
                                            {
                                                student.FinishDate = new DateTime(ano, mes, 1);
                                            }
                                            catch (Exception dateException)
                                            {
                                                dateException.ToString();
                                            }
                                        }
                                    }
                                    student.MatriculationLocking = reader["trancamento"] == DBNull.Value ? null : (string)reader["trancamento"];
                                    //studentInfoViewModel.ClassId = reader["XXX"] == DBNull.Value ? null : (object)reader["XXX"];
                                    student.MatriculationStatus = reader["reg_matric"] == DBNull.Value ? null : (bool?)(Convert.ToString(reader["reg_matric"])).ToUpper().Equals("S");
                                    student.Comments = reader["obs"] == DBNull.Value ? null : (string)reader["obs"];
                                    //studentInfoViewModel.ASAAS_customer_id = reader["XXX"] == DBNull.Value ? null : (object)reader["XXX"];

                                    students.Add(student);
                                }

                                using (var transaction = await context.Database.BeginTransactionAsync())
                                {
                                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Student] ON");
                                    await context.AddRangeAsync(students);
                                    await context.SaveChangesAsync();
                                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Student] OFF");

                                    await transaction.CommitAsync();
                                }
                            }
                            catch (Exception exception)
                            {
                                exception.ToString();
                            }
                        }
                    }
                }
                #endregion
            }

            if (1 == 1)
            {
                #region [Classes]
                var courses = await context.Course.ToListAsync();
                using (var mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection("Server=192.185.216.154;Database=ibrat521_bdados2010;Uid=ibrat521_bdados;Pwd=@Intensivy1314;"))
                {
                    await mySqlConnection.OpenAsync();
                    using (var mySqlCommand = new MySqlCommand("SELECT * FROM turmas;", mySqlConnection))
                    {
                        using (var reader = await mySqlCommand.ExecuteReaderAsync())
                        {
                            var classes = new List<ApplicationDbContext.Class>();
                            try
                            {
                                while (await reader.ReadAsync())
                                {
                                    var _class = new ApplicationDbContext.Class();

                                    if (reader["estado"] == DBNull.Value) continue;

                                    _class.ClassId = (int)reader["cod"];
                                    _class.CourseId = courses.Single(x => x.Name.ToUpper().Equals(((string)reader["curso"]).ToUpper())).CourseId;
                                    _class.State = (string)reader["estado"];
                                    _class.Year = Convert.ToInt32(reader["ano"]);
                                    _class.Info = (string)reader["obs"];
                                    classes.Add(_class);
                                }

                                using (var transaction = await context.Database.BeginTransactionAsync())
                                {
                                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Class] ON");
                                    await context.Class.AddRangeAsync(classes);
                                    await context.SaveChangesAsync();
                                    await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Class] OFF");

                                    await transaction.CommitAsync();
                                }
                            }
                            catch (Exception exception)
                            {
                                exception.ToString();
                            }
                        }
                    }
                }
                #endregion
            }

            if (1 == 1)
            {
                #region [ClassStudents]
                using (var mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection("Server=192.185.216.154;Database=ibrat521_bdados2010;Uid=ibrat521_bdados;Pwd=@Intensivy1314;"))
                {
                    await mySqlConnection.OpenAsync();
                    using (var mySqlCommand = new MySqlCommand("SELECT * FROM alunos;", mySqlConnection))
                    {
                        using (var reader = await mySqlCommand.ExecuteReaderAsync())
                        {
                            var classStudents = new List<ApplicationDbContext.ClassStudent>();
                            try
                            {
                                while (await reader.ReadAsync())
                                {
                                    if ((reader["turma_id"] == DBNull.Value || (string.IsNullOrWhiteSpace((string)reader["turma_id"])) && !int.TryParse((string)reader["turma_id"], out int _))) continue;

                                    var classStudent = new ApplicationDbContext.ClassStudent();
                                    classStudent.StudentId = (int)reader["cod"];
                                    classStudent.ClassId = Convert.ToInt32(reader["turma_id"]);

                                    classStudents.Add(classStudent);
                                }

                                using (var transaction = await context.Database.BeginTransactionAsync())
                                {
                                    await context.AddRangeAsync(classStudents);
                                    await context.SaveChangesAsync();
                                    await transaction.CommitAsync();
                                }
                            }
                            catch (Exception exception)
                            {
                                exception.ToString();
                            }
                        }
                    }
                }
                #endregion
            }

            if (1 == 1)
            {
                #region [ClassStudentDocument]
                using (var mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection("Server=192.185.216.154;Database=ibrat521_bdados2010;Uid=ibrat521_bdados;Pwd=@Intensivy1314;"))
                {
                    await mySqlConnection.OpenAsync();
                    using (var mySqlCommand = new MySqlCommand("SELECT * FROM alunos;", mySqlConnection))
                    {
                        using (var reader = await mySqlCommand.ExecuteReaderAsync())
                        {
                            var classStudents = await context.ClassStudent.ToListAsync();
                            var studentDocuments = new List<ApplicationDbContext.StudentDocument>();
                            try
                            {
                                while (await reader.ReadAsync())
                                {
                                    if ((reader["turma_id"] == DBNull.Value || (string.IsNullOrWhiteSpace((string)reader["turma_id"])) && !int.TryParse((string)reader["turma_id"], out int _))) continue;

                                    var classId = Convert.ToInt32(reader["turma_id"]);
                                    var studentId = (int)reader["cod"];

                                    var classStudent = classStudents.SingleOrDefault(x => x.ClassId == classId && x.StudentId == studentId);
                                    if (classStudent == null) continue;

                                    var studentDocument = new ApplicationDbContext.StudentDocument();

                                    studentDocument.ClassStudentId = classStudent.ClassStudentId;

                                    studentDocument.InternshipDocument1 = !IsNull(reader["estagio1"]);
                                    studentDocument.InternshipDocument2 = !IsNull(reader["estagio2"]);
                                    studentDocument.InternshipComments = reader["obsest"] == DBNull.Value ? null : (string)reader["obsest"];

                                    studentDocument.Contract = !IsNull(reader["docinst1"]);
                                    studentDocument.Photos = !IsNull(reader["docinst2"]);
                                    studentDocument.MatriculationForm = !IsNull(reader["docinst3"]);
                                    studentDocument.InternalRegulation = !IsNull(reader["docinst4"]);
                                    studentDocument.MatriculationRequirement = !IsNull(reader["docinst5"]);
                                    studentDocument.ThesisAgreementTerm = !IsNull(reader["docinst6"]);
                                    studentDocument.InternshipAgreementTerm = !IsNull(reader["docinst7"]);
                                    studentDocument.InstituteDocumentationComments = reader["obsdocinst"] == DBNull.Value ? null : (string)reader["obsdocinst"];

                                    studentDocument.GraduationCertificate = GetDocProfStatus(reader["docpro1"]);
                                    studentDocument.CertifiedOfSpecialization = GetDocProfStatus(reader["docpro2"]);
                                    studentDocument.RegionalCouncilDocument = GetDocProfStatus(reader["docpro3"]);
                                    studentDocument.UtiTimeDeclaration = GetDocProfStatus(reader["docpro4"]);
                                    studentDocument.LeadershipStatement = GetDocProfStatus(reader["docpro5"]);
                                    studentDocument.TeachingDeclaration = GetDocProfStatus(reader["docpro6"]);
                                    studentDocument.CurriculumSummary = GetDocProfStatus(reader["docpro7"]);
                                    studentDocument.ProfessionalDocumentationCommets = reader["obsdocpro"] == DBNull.Value ? null : (string)reader["obsdocpro"];

                                    studentDocument.RegularlyMatriculatedDeclaration = !IsNull(reader["docibrati2"]);
                                    studentDocument.RegularlyMatriculatedDate = reader["dtdocibrati2"] == DBNull.Value ? null : (string)reader["dtdocibrati2"];
                                    studentDocument.CertifiedOfMPTI = !IsNull(reader["docibrati3"]);
                                    studentDocument.CertifiedOfMPTIDate = reader["dtdocibrati3"] == DBNull.Value ? null : (string)reader["dtdocibrati3"];
                                    studentDocument.DocumentOfCNI = !IsNull(reader["docibrati5"]);
                                    studentDocument.DocumentOfCNIDate = reader["dtdocibrati5"] == DBNull.Value ? null : (string)reader["dtdocibrati5"];
                                    studentDocument.DocumentsSentComments = reader["obsdocibrati"] == DBNull.Value ? null : (string)reader["obsdocibrati"];

                                    studentDocument.GeneralComments = reader["obs"] == DBNull.Value ? null : (string)reader["obs"];

                                    studentDocuments.Add(studentDocument);
                                }

                                using (var transaction = await context.Database.BeginTransactionAsync())
                                {
                                    await context.AddRangeAsync(studentDocuments);
                                    await context.SaveChangesAsync();
                                    await transaction.CommitAsync();
                                }
                            }
                            catch (Exception exception)
                            {
                                exception.ToString();
                            }
                        }
                    }
                }
                #endregion
            }

            if (1 == 1)
            {
                #region [Tesis]
                using (var mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection("Server=192.185.216.154;Database=ibrat521_bdados2010;Uid=ibrat521_bdados;Pwd=@Intensivy1314;"))
                {
                    await mySqlConnection.OpenAsync();
                    using (var mySqlCommand = new MySqlCommand("select * from teses t inner join alunos a on t.tese_cpf = a.cpf and t.tese_cpf  is not null AND t.tese_Cpf <> '';", mySqlConnection))
                    {
                        using (var reader = await mySqlCommand.ExecuteReaderAsync())
                        {
                            var classStudents = await context.ClassStudent.ToListAsync();
                            var studentThesiss = new List<ApplicationDbContext.Thesis>();
                            try
                            {
                                while (await reader.ReadAsync())
                                {
                                    if ((reader["turma_id"] == DBNull.Value || (string.IsNullOrWhiteSpace((string)reader["turma_id"])) && !int.TryParse((string)reader["turma_id"], out int _))) continue;

                                    var classId = Convert.ToInt32(reader["turma_id"]);
                                    var studentId = (int)reader["cod"];

                                    var classStudent = classStudents.SingleOrDefault(x => x.ClassId == classId && x.StudentId == studentId);
                                    if (classStudent == null) continue;


                                    var studentThesis = new ApplicationDbContext.Thesis();

                                    studentThesis.ClassStudentId = classStudent.ClassStudentId;
                                    studentThesis.Title = reader["monotitulo"] == DBNull.Value ? null : (string)reader["monotitulo"];
                                    studentThesis.ApprovalDate = reader["monodtaprov"] == DBNull.Value ? null : (string)reader["monodtaprov"];
                                    studentThesis.PresentationDate = reader["monodtapres"] == DBNull.Value ? null : (string)reader["monodtapres"];
                                    studentThesis.Advisor = reader["tese_orientador"] == DBNull.Value ? null : (string)reader["tese_orientador"];
                                    studentThesis.ProtocolNumber = reader["tese_numero"] == DBNull.Value ? null : (int?)reader["tese_numero"];
                                    studentThesis.ProtocolDate = reader["tese_data_inclusao"] == DBNull.Value ? null : (string)reader["tese_data_inclusao"];
                                    studentThesis.Concept = reader["monoconceito"] == DBNull.Value ? null : (string)reader["monoconceito"];
                                    studentThesis.FileName = IsNull(reader["tese_arquivo"]) ? null : (string)reader["tese_arquivo"];

                                    studentThesiss.Add(studentThesis);
                                }

                                using (var transaction = await context.Database.BeginTransactionAsync())
                                {
                                    await context.AddRangeAsync(studentThesiss);
                                    await context.SaveChangesAsync();
                                    await transaction.CommitAsync();
                                }
                            }
                            catch (Exception exception)
                            {
                                exception.ToString();
                            }
                        }
                    }
                }
                #endregion
            }

            if (1 == 1)
            {
                #region [StudentPresenceSituation]
                using (var mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection("Server=192.185.216.154;Database=ibrat521_bdados2010;Uid=ibrat521_bdados;Pwd=@Intensivy1314;"))
                {
                    await mySqlConnection.OpenAsync();
                    using (var mySqlCommand = new MySqlCommand("SELECT * FROM alunos a JOIN presencas p ON a.cod = p.aluno_id;", mySqlConnection))
                    {
                        using (var reader = await mySqlCommand.ExecuteReaderAsync())
                        {
                            var classStudents = await context.ClassStudent.ToListAsync();
                            var studentPresenceSituations = new List<ApplicationDbContext.StudentPresenceSituation>();
                            try
                            {
                                int i = 1;
                                while (await reader.ReadAsync())
                                {
                                    Console.WriteLine($"Cound: {i++}.");
                                    if ((reader["turma_id"] == DBNull.Value || (string.IsNullOrWhiteSpace((string)reader["turma_id"])) && !int.TryParse((string)reader["turma_id"], out int _))) continue;

                                    var classId = Convert.ToInt32(reader["turma_id"]);
                                    var studentId = (int)reader["cod"];
                                    var classStudent = classStudents.SingleOrDefault(x => x.ClassId == classId && x.StudentId == studentId);
                                    if (classStudent == null) continue;

                                    //using (var mySqlConnection2 = new MySql.Data.MySqlClient.MySqlConnection("Server=192.185.216.154;Database=ibrat521_bdados2010;Uid=ibrat521_bdados;Pwd=@Intensivy1314;"))
                                    //{
                                    //    await mySqlConnection2.OpenAsync();
                                    //    using (var mySqlCommand2 = new MySqlCommand($"SELECT * FROM presencas WHERE aluno_id = {studentId};", mySqlConnection2))
                                    //    {
                                    //        using (var reader2 = await mySqlCommand2.ExecuteReaderAsync())
                                    //        {
                                    //            try
                                    //            {
                                    //                while (await reader2.ReadAsync())
                                    //                {
                                    if (reader["mod1_1"] != DBNull.Value || reader["mod1_2"] != DBNull.Value) studentPresenceSituations.Add(new ApplicationDbContext.StudentPresenceSituation() { ClassStudentId = classStudent.ClassStudentId, Module = 1, Saturday = GetStatus(reader["mod1_1"]), SaturdayComments = GetComments(reader["mod1_1_1"]), Sunday = GetStatus(reader["mod1_2"]), SundayComments = GetComments(reader["mod1_2_1"]), Comments = (reader["obsmod"] != DBNull.Value ? (string)reader["obsmod"] : null) });
                                    if (reader["mod2_1"] != DBNull.Value || reader["mod2_2"] != DBNull.Value) studentPresenceSituations.Add(new ApplicationDbContext.StudentPresenceSituation() { ClassStudentId = classStudent.ClassStudentId, Module = 2, Saturday = GetStatus(reader["mod2_1"]), SaturdayComments = GetComments(reader["mod2_1_1"]), Sunday = GetStatus(reader["mod2_2"]), SundayComments = GetComments(reader["mod2_2_1"]), Comments = (reader["obsmod"] != DBNull.Value ? (string)reader["obsmod"] : null) });
                                    if (reader["mod3_1"] != DBNull.Value || reader["mod3_2"] != DBNull.Value) studentPresenceSituations.Add(new ApplicationDbContext.StudentPresenceSituation() { ClassStudentId = classStudent.ClassStudentId, Module = 3, Saturday = GetStatus(reader["mod3_1"]), SaturdayComments = GetComments(reader["mod3_1_1"]), Sunday = GetStatus(reader["mod3_2"]), SundayComments = GetComments(reader["mod3_2_1"]), Comments = (reader["obsmod"] != DBNull.Value ? (string)reader["obsmod"] : null) });
                                    if (reader["mod4_1"] != DBNull.Value || reader["mod4_2"] != DBNull.Value) studentPresenceSituations.Add(new ApplicationDbContext.StudentPresenceSituation() { ClassStudentId = classStudent.ClassStudentId, Module = 4, Saturday = GetStatus(reader["mod4_1"]), SaturdayComments = GetComments(reader["mod4_1_1"]), Sunday = GetStatus(reader["mod4_2"]), SundayComments = GetComments(reader["mod4_2_1"]), Comments = (reader["obsmod"] != DBNull.Value ? (string)reader["obsmod"] : null) });
                                    if (reader["mod5_1"] != DBNull.Value || reader["mod5_2"] != DBNull.Value) studentPresenceSituations.Add(new ApplicationDbContext.StudentPresenceSituation() { ClassStudentId = classStudent.ClassStudentId, Module = 5, Saturday = GetStatus(reader["mod5_1"]), SaturdayComments = GetComments(reader["mod5_1_1"]), Sunday = GetStatus(reader["mod5_2"]), SundayComments = GetComments(reader["mod5_2_1"]), Comments = (reader["obsmod"] != DBNull.Value ? (string)reader["obsmod"] : null) });
                                    if (reader["mod6_1"] != DBNull.Value || reader["mod6_2"] != DBNull.Value) studentPresenceSituations.Add(new ApplicationDbContext.StudentPresenceSituation() { ClassStudentId = classStudent.ClassStudentId, Module = 6, Saturday = GetStatus(reader["mod6_1"]), SaturdayComments = GetComments(reader["mod6_1_1"]), Sunday = GetStatus(reader["mod6_2"]), SundayComments = GetComments(reader["mod6_2_1"]), Comments = (reader["obsmod"] != DBNull.Value ? (string)reader["obsmod"] : null) });
                                    if (reader["mod7_1"] != DBNull.Value || reader["mod7_2"] != DBNull.Value) studentPresenceSituations.Add(new ApplicationDbContext.StudentPresenceSituation() { ClassStudentId = classStudent.ClassStudentId, Module = 7, Saturday = GetStatus(reader["mod7_1"]), SaturdayComments = GetComments(reader["mod7_1_1"]), Sunday = GetStatus(reader["mod7_2"]), SundayComments = GetComments(reader["mod7_2_1"]), Comments = (reader["obsmod"] != DBNull.Value ? (string)reader["obsmod"] : null) });
                                    if (reader["mod8_1"] != DBNull.Value || reader["mod8_2"] != DBNull.Value) studentPresenceSituations.Add(new ApplicationDbContext.StudentPresenceSituation() { ClassStudentId = classStudent.ClassStudentId, Module = 8, Saturday = GetStatus(reader["mod8_1"]), Sunday = GetStatus(reader["mod8_2"]), Comments = (reader["obsmod"] != DBNull.Value ? (string)reader["obsmod"] : null) });


                                    //            }
                                    //        }
                                    //        catch (Exception exception)
                                    //        {
                                    //            exception.ToString();
                                    //        }
                                    //    }
                                    //}
                                }

                                using (var transaction = await context.Database.BeginTransactionAsync())
                                {
                                    await context.AddRangeAsync(studentPresenceSituations);
                                    await context.SaveChangesAsync();
                                    await transaction.CommitAsync();
                                }
                            }
                            catch (Exception exception)
                            {
                                exception.ToString();
                            }
                        }
                    }
                }
                #endregion
            }

            if (1 == 1)
            {
                #region [Finance]
                using (var mySqlConnection = new MySql.Data.MySqlClient.MySqlConnection("Server=192.185.216.154;Database=ibrat521_bdados2010;Uid=ibrat521_bdados;Pwd=@Intensivy1314;"))
                {
                    await mySqlConnection.OpenAsync();
                    using (var mySqlCommand = new MySqlCommand("SELECT * FROM alunos a JOIN pagamentos p ON a.cod = p.aluno_id;", mySqlConnection))
                    {
                        using (var reader = await mySqlCommand.ExecuteReaderAsync())
                        {
                            var classStudents = await context.ClassStudent.ToListAsync();
                            var finances = new List<ApplicationDbContext.Finance>();
                            try
                            {
                                int i = 1;
                                while (await reader.ReadAsync())
                                {
                                    Console.WriteLine($"Cound: {i++}.");
                                    if ((reader["turma_id"] == DBNull.Value || (string.IsNullOrWhiteSpace((string)reader["turma_id"])) && !int.TryParse((string)reader["turma_id"], out int _))) continue;

                                    var classId = Convert.ToInt32(reader["turma_id"]);
                                    var studentId = (int)reader["cod"];
                                    var classStudent = classStudents.SingleOrDefault(x => x.ClassId == classId && x.StudentId == studentId);
                                    if (classStudent == null) continue;

                                    if ((reader["venc1"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc1"])) || (reader["pgto1"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto1"])) || (reader["referente1"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente1"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc1"]), Payment = GetComments(reader["pgto1"]), Installment = GetComments(reader["referente1"]) });
                                    if ((reader["venc2"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc2"])) || (reader["pgto2"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto2"])) || (reader["referente2"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente2"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc2"]), Payment = GetComments(reader["pgto2"]), Installment = GetComments(reader["referente2"]) });
                                    if ((reader["venc3"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc3"])) || (reader["pgto3"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto3"])) || (reader["referente3"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente3"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc3"]), Payment = GetComments(reader["pgto3"]), Installment = GetComments(reader["referente3"]) });
                                    if ((reader["venc4"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc4"])) || (reader["pgto4"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto4"])) || (reader["referente4"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente4"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc4"]), Payment = GetComments(reader["pgto4"]), Installment = GetComments(reader["referente4"]) });
                                    if ((reader["venc5"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc5"])) || (reader["pgto5"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto5"])) || (reader["referente5"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente5"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc5"]), Payment = GetComments(reader["pgto5"]), Installment = GetComments(reader["referente5"]) });
                                    if ((reader["venc6"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc6"])) || (reader["pgto6"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto6"])) || (reader["referente6"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente6"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc6"]), Payment = GetComments(reader["pgto6"]), Installment = GetComments(reader["referente6"]) });
                                    if ((reader["venc7"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc7"])) || (reader["pgto7"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto7"])) || (reader["referente7"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente7"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc7"]), Payment = GetComments(reader["pgto7"]), Installment = GetComments(reader["referente7"]) });
                                    if ((reader["venc8"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc8"])) || (reader["pgto8"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto8"])) || (reader["referente8"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente8"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc8"]), Payment = GetComments(reader["pgto8"]), Installment = GetComments(reader["referente8"]) });
                                    if ((reader["venc9"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc9"])) || (reader["pgto9"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto9"])) || (reader["referente9"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente9"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc9"]), Payment = GetComments(reader["pgto9"]), Installment = GetComments(reader["referente9"]) });
                                    if ((reader["venc10"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc10"])) || (reader["pgto10"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto10"])) || (reader["referente10"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente10"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc10"]), Payment = GetComments(reader["pgto10"]), Installment = GetComments(reader["referente10"]) });
                                    if ((reader["venc11"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc11"])) || (reader["pgto11"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto11"])) || (reader["referente11"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente11"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc11"]), Payment = GetComments(reader["pgto11"]), Installment = GetComments(reader["referente11"]) });
                                    if ((reader["venc12"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc12"])) || (reader["pgto12"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto12"])) || (reader["referente12"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente12"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc12"]), Payment = GetComments(reader["pgto12"]), Installment = GetComments(reader["referente12"]) });
                                    if ((reader["venc13"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc13"])) || (reader["pgto13"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto13"])) || (reader["referente13"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente13"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc13"]), Payment = GetComments(reader["pgto13"]), Installment = GetComments(reader["referente13"]) });
                                    if ((reader["venc14"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc14"])) || (reader["pgto14"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto14"])) || (reader["referente14"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente14"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc14"]), Payment = GetComments(reader["pgto14"]), Installment = GetComments(reader["referente14"]) });
                                    if ((reader["venc15"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc15"])) || (reader["pgto15"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto15"])) || (reader["referente15"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente15"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc15"]), Payment = GetComments(reader["pgto15"]), Installment = GetComments(reader["referente15"]) });
                                    if ((reader["venc16"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc16"])) || (reader["pgto16"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto16"])) || (reader["referente16"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente16"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc16"]), Payment = GetComments(reader["pgto16"]), Installment = GetComments(reader["referente16"]) });
                                    if ((reader["venc17"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc17"])) || (reader["pgto17"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto17"])) || (reader["referente17"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente17"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc17"]), Payment = GetComments(reader["pgto17"]), Installment = GetComments(reader["referente17"]) });
                                    if ((reader["venc18"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["venc18"])) || (reader["pgto18"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["pgto18"])) || (reader["referente18"] != DBNull.Value && !string.IsNullOrWhiteSpace((string)reader["referente18"]))) finances.Add(new Finance() { ClassStudentId = classStudent.ClassStudentId, DueDate = GetComments(reader["venc18"]), Payment = GetComments(reader["pgto18"]), Installment = GetComments(reader["referente18"]) });



                                }

                                using (var transaction = await context.Database.BeginTransactionAsync())
                                {
                                    await context.AddRangeAsync(finances);
                                    await context.SaveChangesAsync();
                                    await transaction.CommitAsync();
                                }
                            }
                            catch (Exception exception)
                            {
                                exception.ToString();
                            }
                        }
                    }
                }
                #endregion
            }
        }

        static int? GetStatus(object o)
        {
            if (o == DBNull.Value) return null;

            switch (((string)o).ToUpper())
            {
                case "A":
                    return 1; // Abono
                case "F":
                    return 2; // Falta
                case "P":
                    return 3; // Presença
                case "R":
                    return 4; // Reposição
                default:
                    return null;
            }

        }
        static int? GetDocProfStatus(object o)
        {
            if (o == DBNull.Value) return null;

            switch (((string)o).ToUpper())
            {
                case "NÃO ENTREGOU":
                case "NÏ¿½O ENTREGOU":
                    return 2; // Abono
                case "NÃO POSSUI":
                    return 3; // Falta
                case "-- SELECIONE --":
                    return null;
                default:
                    return 1;
            }

        }
        static string GetComments(object o)
        {
            if (o == DBNull.Value || string.IsNullOrWhiteSpace((string)o)) return null;

            return (string)o;
        }
        static bool IsNull(object o)
        {
            return (o == DBNull.Value || string.IsNullOrWhiteSpace((string)o));
        }
    }
}
