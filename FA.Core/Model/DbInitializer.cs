using FA.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FA.Project.Model
{
    public class DbInitializer
    {
        public static void Seed(TMSContext context)
        {
            context.Database.EnsureCreated();
            if (context.ClassAdmins.Any())
            {
                return;
            }

            var classAdmins = new ClassAdmin[]
            {
                new ClassAdmin()
                {
                    FullName="Nguyen Van An",
                 //   DateOfBirth=new DateTimeOffset(new DateTime(1999,01,01)),
                      DateOfBirth = new DateTime(1958, 8, 27),
                      Gender=true,
                      PhoneNumber="+8409987654",
                      Email="An@gmail.com",
                      Account="AnNT1",
                      AuditTrail="Audi1",
                      isDelete=false

                },
                 new ClassAdmin()
                {
                    FullName="Nguyen Van Phuc",
                 //   DateOfBirth=new DateTimeOffset(new DateTime(1999,01,01)),
                      DateOfBirth = new DateTime(1970, 8, 20),
                      Gender=true,
                      PhoneNumber="+8409987654",
                      Email="Phuc@gmail.com",
                      Account="PhucCT",
                      AuditTrail="Audi2",
                      isDelete=false

                },
                  new ClassAdmin()
                {
                    FullName="Nguyen Ngoc Anh",
                 //   DateOfBirth=new DateTimeOffset(new DateTime(1999,01,01)),
                      DateOfBirth = new DateTime(1990, 9, 27),
                      Gender=false,
                      PhoneNumber="+8409987654",
                      Email="AnH@gmail.com",
                      Account="AnhNT",
                      AuditTrail="Audi3",
                      isDelete=false

                }
            };
            context.ClassAdmins.AddRange(classAdmins);


            var classBatches = new ClassBatch[]
            {
                new ClassBatch()
                {
                    ClassName="CShap",
                    ClassCode="SE1301",
                    GroupMail="fsoft@gmail.com",
                    StartDate=new DateTime(2020,06,06),
                    EndDate  =new DateTime(2020,09,12),
                    Location="Hoa Lac",
                    DetailLocation="Zone 9",
                    Remarks="net 1",
                    AuditTrail="audi 1",
                    isDeleted=false

                },
                 new ClassBatch()
                {
                    ClassName="Java",
                    ClassCode="SE1302",
                    GroupMail="fsoft@gmail.com",
                    StartDate=new DateTime(2020,06,06),
                    EndDate  =new DateTime(2020,09,12),
                    Location="Hoa Lac",
                    DetailLocation="Zone 10",
                    Remarks="java 1",
                    AuditTrail="audi 2",
                    isDeleted=false

                },
                  new ClassBatch()
                {
                    ClassName="HTML",
                    ClassCode="SE1303",
                    GroupMail="fsoft@gmail.com",
                    StartDate=new DateTime(2020,06,06),
                    EndDate  =new DateTime(2020,09,12),
                    Location="Hoa Lac",
                    DetailLocation="Zone 11",
                    Remarks="html 1",
                    AuditTrail="audi 3",
                    isDeleted=false

                }
            };
            context.ClassBatches.AddRange(classBatches);




        


            var trainers = new Trainer[]
            {
                new Trainer()
                {
                    FullName="Cong DX",
                    DateOfBirth=DateTime.Now,
                    Gender=true,
                    PhoneNumber="8487554321",
                    Email="CongDX@gmail.com",
                    Account="CongDx",
                    Type="trainer",
                    Unit=".net",
                   Experience=3,
                   Remarks=".net",
                   AuditTrail="audit 1",
                   isDelete=false

                },
                new Trainer()
                {
                    FullName="Toan HK",
                    DateOfBirth=new DateTime(1980,07,07),
                    Gender=true,
                    PhoneNumber="+8487554321",
                    Email="ToanHK@gmail.com",
                    Account="ToanKHK",
                    Type="trainer",
                    Unit=".net",
                   Experience=5,
                   Remarks=".net",
                   AuditTrail="audit 1",
                   isDelete=false

                },
                new Trainer()
                {
                    FullName="Huyen Le",
                    DateOfBirth=new DateTime(1991,07,07),
                    Gender=false,
                    PhoneNumber="+8487554321",
                    Email="HuyenLTT@gmail.com",
                    Account="HuyenLTT",
                    Type="Admin",
                    Unit=".net",
                   Experience=3,
                   Remarks=".net",
                   AuditTrail="audit 1",
                   isDelete=false

                }

            };
            context.Trainers.AddRange(trainers);

            var classAdminBatchs = new ClassAdminBatch[]
            {
                 new ClassAdminBatch()
                 {
                     ClassAdmin = classAdmins.Single(p=>p.FullName=="Nguyen Van An"),
                     ClassBatch=classBatches.Single(k=>k.ClassName=="CShap")
                     
                 },
                  new ClassAdminBatch()
                 {
                     ClassAdmin = classAdmins.Single(p=>p.FullName=="Nguyen Van Phuc"),
                     ClassBatch=classBatches.Single(k=>k.ClassName=="Java")
                 },
                   new ClassAdminBatch()
                 {
                     ClassAdmin = classAdmins.Single(p=>p.FullName=="Nguyen Ngoc Anh"),
                     ClassBatch=classBatches.Single(k=>k.ClassName=="HTML")
                 }
            };
            context.ClassAdminBatches.AddRange(classAdminBatchs);

            var trainerClassBatch = new TrainerClassBatch[]
            {
                new TrainerClassBatch()
                {
                    Trainer=trainers.Single(p=>p.FullName=="Cong DX"),
                    ClassBatch=classBatches.Single(x=>x.ClassName=="CShap")
                },
                new TrainerClassBatch()
                {
                    Trainer=trainers.Single(p=>p.FullName=="Toan HK"),
                    ClassBatch=classBatches.Single(x=>x.ClassName=="Java")
                },
                new TrainerClassBatch()
                {
                    Trainer=trainers.Single(p=>p.FullName=="Huyen Le"),
                    ClassBatch=classBatches.Single(x=>x.ClassName=="HTML")
                }
            };
            context.TrainerClassBatches.AddRange(trainerClassBatch);

            var trainees = new Trainee[]
        {
                new Trainee()
                {
                    FullName="Vinh Cao",
                    DateOfBirth=DateTime.Now,
                   
                    PhoneNumber="8400009999",
                    FamilyPhoneNumber="0987442",
                    Email = "giang@gmail.com",
                    ExternalEmail="giang@gmail.com",
                    Account="GiangTV2",
                    
                    Remarks="A18",
                    University="FPT",
                    Faculty="SE",

                    ForeignLanguage="English",
                    Level=1,
                    AllocationStatus="Thach Hoa",
                    AuditTrail="Audi",
                    isDelete=true,
                     CV="CV3",
                     ClassBatch=classBatches.Single(c=>c.ClassCode=="SE1301"),
                   //  ClassBatchId=classBatches[0].ClassBatchId
                },

                 new Trainee()
                {
                     FullName="Cong nguyen",
                    DateOfBirth=DateTime.Now,
                 //   Gender = false,
                    PhoneNumber="8400009999",
                    FamilyPhoneNumber="0987442",
                    Email = "congnt@gmail.com",
                    ExternalEmail="giang@gmail.com",
                    Account="CongNT22",

                    Remarks="F18",
                    University="FPT",
                    Faculty="SE",

                    ForeignLanguage="English",
                    Level=1,
                    AllocationStatus="Thach Hoa",
                    AuditTrail="Audi",
                    isDelete=true,
                     CV="CV2",
                      ClassBatch=classBatches.Single(h=>h.ClassCode=="SE1302"),

                },
                  new Trainee()
                {
                      FullName="Vu nguyen",
                    DateOfBirth=DateTime.Now,
                   // Gender = true,
                    PhoneNumber="8400009999",
                    FamilyPhoneNumber="0987442",
                    Email = "vinhg@gmail.com",
                    ExternalEmail="vinh@gmail.com",
                    Account="vinhct",

                    Remarks="A18",
                    University="FPT",
                    Faculty="SE",

                    ForeignLanguage="English",
                    Level=1,
                    AllocationStatus="Thach Hoa",
                    AuditTrail="Audi",
                    isDelete=true,
                    CV="CV1",
                     ClassBatch=classBatches.Single(h=>h.ClassCode=="SE1303"),

                },
                   new Trainee()
                {
                     FullName="Cong abc",
                    DateOfBirth=DateTime.Now,
                 //   Gender = false,
                    PhoneNumber="8400009998",
                    FamilyPhoneNumber="0987442",
                    Email = "congntt@gmail.com",
                    ExternalEmail="giang@gmail.com",
                    Account="CongNT22",

                    Remarks="F18",
                    University="FPT",
                    Faculty="SE",

                    ForeignLanguage="English",
                    Level=1,
                    AllocationStatus="Thach Hoa",
                    //AuditTrail="Audi",
                    isDelete=true,
                     CV="CV2",
                    ClassBatch=classBatches.Single(h=>h.ClassCode=="SE1302"),

                }
        };
            context.Trainees.AddRange(trainees);

            var requests = new Request[]
           {
                new Request()
                {
                Reason="late by bus",StartDate=DateTime.Now,
                    EndDate=DateTime.Now,ComimmingTime=TimeSpan.Zero,LeavingTime=TimeSpan.Zero,
                    ExpectedApproval=DateTime.Now,
                    //Status="Draft",
                    AuditTrail="Audi",
                    isDelete=true,
                    Trainee = trainees.Single(t=>t.FullName=="Vinh Cao"),
                    ClassAdmin = classAdmins.Single(p=>p.FullName=="Nguyen Van An")
                },
                new Request()
                {
                Reason="weak health",StartDate=DateTime.Now,
                    EndDate=DateTime.Now,ComimmingTime=TimeSpan.Zero,LeavingTime=TimeSpan.Zero,
                    ExpectedApproval=DateTime.Now,
                    //Status="Draft",
                    AuditTrail="Audi",
                    isDelete=true,
                     Trainee = trainees.Single(t=>t.FullName=="Vu nguyen"),
                      ClassAdmin = classAdmins.Single(p=>p.FullName=="Nguyen Van Phuc")
                },
                new Request()
                {

                    Reason="outside with customer",
                    StartDate=DateTime.Now,
                    EndDate=DateTime.Now,ComimmingTime=TimeSpan.Zero,LeavingTime=TimeSpan.Zero,
                    ExpectedApproval=DateTime.Now,
                    //Status="Draft",
                    AuditTrail="Audi",
                    isDelete=true,
                     Trainee = trainees.Single(t=>t.FullName=="Cong nguyen"),
                      ClassAdmin = classAdmins.Single(p=>p.FullName=="Nguyen Ngoc Anh")
                },
           };
            context.Requests.AddRange(requests);



            context.SaveChanges();
        }
    }
}
