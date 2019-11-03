using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;
using System;

namespace CompanyTests
{
    [TestClass]
    public class CompanyManagerTest
    {
        [TestMethod]
        public void Appoint_ValidData_ChangesEmployeesPosition()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddManager("M1", "Head");
            cm.AddWorker("W1", "M1");
            cm.Hire("Tom", "3200", "W1");
            cm.Appoint("0", "M1");
        }

        [TestMethod]
        public void Fire_ValidData_RemovesEmployee()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddManager("M1", "Head");
            cm.Hire("Tom", "3200", "M1");
            cm.Fire("0");
        }

        [TestMethod]
        public void Hire_ValidData_AddsEmployee()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddManager("M1", "Head");
            cm.Hire("Tom", "3200", "M1");
        }

        [TestMethod]
        public void Hire_InvalidName_ShouldThrowFormatException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddManager("M1", "Head");
            Assert.ThrowsException<FormatException>(() => cm.Hire(".Tom", "3200", "M1"));
        }

        [TestMethod]
        public void Hire_InvalidSalary_ShouldThrowArgumentOutOfRangeException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddManager("M1", "Head");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => cm.Hire("Tom", "-3200", "M1"));
        }

        [TestMethod]
        public void Hire_InvalidPositionName_ShouldThrowPositionDoesNotExistException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddManager("M1", "Head");
            Assert.ThrowsException<PositionDoesNotExistException>(() => cm.Hire("Tom", "3200", "W1"));
        }

        [TestMethod]
        public void NewHead_HeadDoesNotExist_AddsHead()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
        }

        [TestMethod]
        public void NewHead_HeadAlreadyExists_ShouldThrowCompanyHeadException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            Assert.ThrowsException<CompanyHeadException>(() => cm.NewHead("SecondHead"));
        }

        [TestMethod]
        public void ChangeHead_ValidData_ChangesHead()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.ChangeHead("SecondHead");
        }

        [TestMethod]
        public void ChangeHead_HeadDoesNotExist_ShouldThrowCompanyHeadException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            Assert.ThrowsException<CompanyHeadException>(() => cm.ChangeHead("SecondHead"));
        }

        [TestMethod]
        public void ChangeHead_ExistedPositionName_ShouldThrowPositionAlreadyExistsException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddManager("SecondHead", "Head");
            Assert.ThrowsException<PositionAlreadyExistsException>(() => cm.ChangeHead("SecondHead"));
        }

        [TestMethod]
        public void AddManager_ValidData_AddsManagerPosition()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddManager("M1", "Head");
        }

        [TestMethod]
        public void AddManager_InvalidSubordinatePositionName_ShouldThrowPositionAlreadyExistsException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddManager("M1", "Head");
            Assert.ThrowsException<PositionAlreadyExistsException>(() => cm.AddManager("M1", "Head"));
        }

        [TestMethod]
        public void AddManager_InvalidSupervisorPositionName_ShouldThrowPositionDoesNotExistException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            Assert.ThrowsException<PositionDoesNotExistException>(() => cm.AddManager("M1", "M2"));
        }

        [TestMethod]
        public void AddManager_InvalidSupervisorPositionType_ShouldThrowPositionCanNotHaveSubordinatesException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddWorker("W1", "Head");
            Assert.ThrowsException<PositionCanNotHaveSubordinatesException>(() => cm.AddManager("M1", "W1"));
        }

        [TestMethod]
        public void AddWorker_ValidData_AddsWorkerPosition()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddWorker("W1", "Head");
        }

        [TestMethod]
        public void AddWorker_InvalidSubordinatePositionName_ShouldThrowPositionAlreadyExistsException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddWorker("W1", "Head");
            Assert.ThrowsException<PositionAlreadyExistsException>(() => cm.AddWorker("W1", "Head"));
        }

        [TestMethod]
        public void AddWorker_InvalidSupervisorPositionName_ShouldThrowPositionDoesNotExistException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            Assert.ThrowsException<PositionDoesNotExistException>(() => cm.AddWorker("W1", "M1"));
        }

        [TestMethod]
        public void AddWorker_InvalidSupervisorPositionType_ShouldThrowPositionCanNotHaveSubordinatesException()
        {
            CompanyManager cm = new CompanyManager(new Company("Test"));
            cm.NewHead("Head");
            cm.AddWorker("W1", "Head");
            Assert.ThrowsException<PositionCanNotHaveSubordinatesException>(() => cm.AddWorker("W2", "W1"));
        }
    }
}
