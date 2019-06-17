using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Hotel.BLL.DTO;
using Hotel.BLL.Interfaces;
using Hotel.Web.Areas.Admin.Models;

namespace Hotel.Web.Areas.Admin.Controllers
{
    public class RoomTypeController : Controller
    {
        private ICrudService<RoomTypeDto> _roomTypeCrudService;
        private ICrudService<ConvenienceDto> _convenienceCrudService;
        private IMapper _mapper;

        public RoomTypeController(ICrudService<RoomTypeDto> roomTypeCrudService, ICrudService<ConvenienceDto> convenienceCrudService, IMapper mapper)
        {
            _roomTypeCrudService = roomTypeCrudService;
            _convenienceCrudService = convenienceCrudService;
            _mapper = mapper;
        }
        
        // GET: Admin/RoomType/List
        [HttpGet]
        public ActionResult List()
        {
            return View(_roomTypeCrudService.GetAll());
        }

        // GET: Admin/RoomType/Create
        [HttpGet]
        public ActionResult Create()
        {
            RoomTypeDetailsVm model = new RoomTypeDetailsVm();
            model.AvailableConveniences = new SelectList(_convenienceCrudService.GetAll(), "Id", "Name");

            
            return View("Details", model);
        }

        // POST: Admin/RoomType/Create
        [HttpPost]
        public ActionResult Create(RoomTypeDetailsVm model, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableConveniences = new SelectList(_convenienceCrudService.GetAll(), "Id", "Name");
                return View("Details", model);
            }

            RoomTypeDto type = _mapper.Map<RoomTypeDto>(model);
            type.PathToImage = "/Content/img/" + image.FileName;
            image.SaveAs(Server.MapPath(type.PathToImage));

            _roomTypeCrudService.Create(type);

            return RedirectToAction("List");
        }

        // GET: Admin/RoomType/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            RoomTypeDto type = _roomTypeCrudService.Get(id);
            RoomTypeDetailsVm model = _mapper.Map<RoomTypeDetailsVm>(type);
            model.AvailableConveniences = new MultiSelectList(_convenienceCrudService.GetAll(), "Id", "Name", type.Conveniences);

            return View("Details", model);
        }

        // POST: Admin/RoomType/Edit
        [HttpPost]
        public ActionResult Edit(RoomTypeDetailsVm model)
        {
            if (!ModelState.IsValid)
            {
                model.AvailableConveniences = new SelectList(_convenienceCrudService.GetAll(), "Id", "Name");
                return View("Details", model);
            }
            

            RoomTypeDto type = _mapper.Map<RoomTypeDto>(model);
            if (model.Image != null)
            {
                type.PathToImage = "/Content/img/" + model.Image.FileName;
                var directory = Directory.CreateDirectory(Server.MapPath("/Content/img"));
                directory.Create();
                model.Image.SaveAs(Server.MapPath(type.PathToImage));
                FileInfo file = directory.EnumerateFiles().FirstOrDefault(x => x.Name == model.Name);
            }

            _roomTypeCrudService.Update(type);

            return RedirectToAction("List");
        }

        // GET: Admin/RoomType/Delete/id
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _roomTypeCrudService.Delete(id);
            return RedirectToAction("List");
        }
    }
}