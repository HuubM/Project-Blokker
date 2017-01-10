using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;

using ProjectBlokker.Controllers;
using ProjectBlokker.Data;
using ProjectBlokker.Models;
using Microsoft.EntityFrameworkCore;

namespace tests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            Afspraak afspraak = new Afspraak()
            {
                ID = 4,
                AfspraakDatum = new DateTime (2017, 08, 21),
                Naam = "Jan",
                TrouwDatum = new DateTime(2017, 09, 09),
                TelNr = 0312214974,
                Email = "Jandebeste@gmail.com",
                Nieuwsbrief = true
            };

            //er zijn 2 mock object nodig
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetAfspraak = new Mock<DbSet<Afspraak>>();

            // Als afspraak uit de DBcontext opgevraagd ook een mock object teruggeven
            mockDbContext.Setup(x => x.Afspraak).Returns(mockDbSetAfspraak.Object);

            AfspraakController ac = new AfspraakController(mockDbContext.Object);

            var result = ac.Add(afspraak);

            mockDbSetAfspraak.Verify(m => m.Add(It.IsAny<Afspraak>()), Times.Once());
            mockDbContext.Verify(m => m.SaveChanges(), Times.Once());

        }
    }
}
