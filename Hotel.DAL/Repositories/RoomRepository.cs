﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Hotel.DomainEntities.EF;
using Hotel.DomainEntities.Entities;
using Hotel.DomainEntities.Interfaces;

namespace Hotel.DomainEntities.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        private HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Room Get(int id)
        {
            return _context.Rooms.Include(r => r.RoomType).FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Room> Find(Func<Room, bool> predicate)
        {
            return _context.Rooms.Where(predicate).ToList();
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.Include(r=>r.RoomType).ToList();
        }

        public void Create(Room item)
        {
            _context.Rooms.Add(item);
            _context.SaveChanges();
        }

        public void Update(Room item)
        {
            Room room = _context.Rooms.Find(item.Id);

            if(room == null)
            {
                throw new ArgumentException("Room with current Id not found");
            }

            _context.Set<Room>().AddOrUpdate(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Room room = _context.Rooms.Find(id);

            if (room == null)
            {
                throw new ArgumentException("Room with current Id not found");
            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }
}
