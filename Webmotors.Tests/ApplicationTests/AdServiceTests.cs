using NUnit.Framework;
using Webmotors.Application.Responses;
using Webmotors.Application.Services;
using Webmotors.Tests.ApplicationTests.Factories;
using Webmotors.Tests.ApplicationTests.Fakes;
using FluentValidation;
using Webmotors.Domain.Models;
using Webmotors.Application.Requests;
using System.Collections.Generic;
using System.Linq;

namespace Webmotors.Tests.ApplicationTests
{
    public class AdServiceTests
    {
        private AdService _service;
        private FakeAdRepository _repository;
        private AdRequestFactory _factory => new AdRequestFactory();

        [SetUp]
        public void Setup()
        {
            this._repository = new FakeAdRepository();
            this._service = new AdService(_repository);
        }

        [Test]
        public void Add_ValidAdRequest_ReturnsAdResponse()
        {
            var request = _factory.GetAdRequest();

            var response = _service.Add(request);

            Assert.IsNotNull(response);
            Assert.AreSame(typeof(AdResponse), response.GetType());
        }

        [Test]
        public void Add_InvalidAdRequest_ThrowsValidationException()
        {
            var request = _factory.GetAdRequest(false);

            TestDelegate testDelegate = new TestDelegate(() => _service.Add(request));

            Assert.Throws<ValidationException>(testDelegate);
        }

        [Test]
        public void Update_ValidAdRequest_ReturnsAdResponse()
        {
            var adRequest = _factory.GetAdRequest();

            var dbObj =_repository.Insert(new Ad(adRequest));

            var request = new AdRequest();
            request.Make = dbObj.Make + " Alterado";
            request.Model = dbObj.Model + " Alterado";
            request.Version = dbObj.Version + "Alterado";
            request.Year = dbObj.Year + 1;
            request.Mileage = dbObj.Mileage + 1;
            request.Note = dbObj.Note + "Alterado";

            var response = _service.Update(dbObj.ID, request);

            Assert.IsNotNull(response);
            Assert.AreSame(typeof(AdResponse), response.GetType());
            Assert.AreEqual(dbObj.ID, response.ID);
            Assert.AreEqual(request.Make, response.Make);
            Assert.AreEqual(request.Model, response.Model);
            Assert.AreEqual(request.Version, response.Version);
            Assert.AreEqual(request.Year, response.Year);
            Assert.AreEqual(request.Mileage, response.Mileage);
            Assert.AreEqual(request.Note, response.Note);
        }

        [Test]
        public void Update_InvalidAdRequest_ThrowsValidationException()
        {
            var adRequest = _factory.GetAdRequest();

            var dbObj = _repository.Insert(new Ad(adRequest));

            var request = new AdRequest();

            TestDelegate testDelegate = new TestDelegate(() => _service.Update(dbObj.ID, request));

            Assert.Throws<ValidationException>(testDelegate);
        }

        [Test]
        public void Get_NoParameters_ReturnsListAdResponse()
        {
            var adRequest = _factory.GetAdRequest();

            var dbObj = _repository.Insert(new Ad(adRequest));

            var response = _service.Get();

            Assert.IsNotNull(response);
            Assert.AreSame(typeof(List<AdResponse>), response.GetType());
            Assert.AreEqual(response.Count(), 1);
        }

        [Test]
        public void Get_ValidId_ReturnsAdResponse()
        {
            var adRequest = _factory.GetAdRequest();

            var dbObj = _repository.Insert(new Ad(adRequest));

            var response = _service.Get(dbObj.ID);

            Assert.IsNotNull(response);
            Assert.AreSame(typeof(AdResponse), response.GetType());
            Assert.AreEqual(dbObj.ID, response.ID);
        }

        [Test]
        public void Get_InvalidId_ReturnsNull()
        {
            var adRequest = _factory.GetAdRequest();

            var dbObj = _repository.Insert(new Ad(adRequest));

            var response = _service.Get(dbObj.ID + 1);

            Assert.IsNull(response);
        }

        [Test]
        public void Remove_ValidId_RemovesRecord()
        {
            var adRequest = _factory.GetAdRequest();

            var dbObj = _repository.Insert(new Ad(adRequest));

            _service.Remove(dbObj.ID);

            Assert.IsNull(_repository.Select(dbObj.ID));
        }

        [Test]
        public void Remove_InvalidId_KeepsRecord()
        {
            var adRequest = _factory.GetAdRequest();

            var dbObj = _repository.Insert(new Ad(adRequest));

            _service.Remove(dbObj.ID + 1);

            Assert.IsNotNull(_repository.Select(dbObj.ID));
        }
    }
}
