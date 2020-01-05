using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CaisseLogicLibrary.DataAccess.Login;
using CaisseSqlLogicLibrary.SqliteDataAccess;
using CaisseDTOsLibrary.Models.LoginAccountModel;
using Moq;
using Autofac.Extras.Moq;
using Dapper;
using System.Data;

namespace Caisse.Tests.LogicLibraryTests
{
     public class loggerTests
     {
          [Fact]
          public void Login_LoginShouldWork()
          {

               using (var mock = AutoMock.GetLoose())
               {
                    //Arrange
                    string query = "select id from LoginAccount where username = @username and password = @password ";
                    mock.Mock<ISqliteDataAccess>()
                         .Setup(x => x.LoadData<LoginAccount, dynamic>(query, It.IsAny<LoginAccount>(), "caisseCnn"))
                         .Returns(
                         new List<LoginAccount>() 
                         { 
                              new LoginAccount() { id = 9 } 
                         });

                    //Act
                    var cls = mock.Create<Logger>();
                    var expected = 9;
                    var actual = cls.Login(It.IsAny<LoginAccount>());

                    //Assert

                    Assert.True(actual > 0);
                    
                    Assert.Equal(expected, actual);
               }

          }
          [Fact]
          public void Login_LoginShouldFail()
          {

               using (var mock = AutoMock.GetLoose())
               {
                    //Arrange
                    string query = "select id from LoginAccount where username = @username and password = @password ";

                    mock.Mock<ISqliteDataAccess>()
                         .Setup(x => x.LoadData<LoginAccount, dynamic>(query, It.IsAny<LoginAccount>(), "caisseCnn"))
                         .Returns(
                         new List<LoginAccount>() 
                         { 
                              
                         });

                    //Act
                    var cls = mock.Create<Logger>();
                    var expected = 0;
                    var actual = cls.Login(It.IsAny<LoginAccount>());

                    //Assert
                    Assert.Equal(expected, actual);
               }

          }
     }
}
