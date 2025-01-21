using AutoFixture;
using Infrastructure.Persistence;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mocks
{
    public class MockAccionRepository
    {
        public static void AddDataAccion(ApplicationDbContext applicationDbContextFake)
        {
            var fixture = new Fixture();

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var accion = fixture.CreateMany<Acciones>().ToList();

            accion.Add(fixture.Build<Acciones>()
                .With(tr => tr.Id, "2a82ff8a-1e33-498f-9367-1f8ff9ec6440")
                .Create()
                );

            applicationDbContextFake.acciones!.AddRange(accion);
            applicationDbContextFake.SaveChanges();
        }
    }
}
