using AutoMapper;
using forum.DTO.Responses;
using Forum.Database.Contexts;
using Forum.Database.Models;
using Forum.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly DatabaseContext db;
        private readonly IMapper mapper;

        public TopicsController(DatabaseContext db,
                               IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public TopicResponse GetSingle(Guid id)
        {
            var entity = db.Topics.SingleOrDefault(t => t.Id == id);
            var result = mapper.Map<TopicResponse>(entity);
            return result;
        }

        [HttpGet]
        public IEnumerable<TopicResponse> Get()
        {
            var entities = db.Topics.ToList();
            var result = mapper.Map<List<TopicResponse>>(entities);
            return result;
        }

        [HttpPost]
        public TopicResponse Post(TopicRequest created)
        {
            var entity = new Topic();
            entity.UpdateFieldsFromRequest(created);
            db.Add(entity);
            db.SaveChanges();
            var result = mapper.Map<TopicResponse>(entity);
            return result;
        }

        [HttpPut]
        public TopicResponse Put(TopicRequest updated)
        {
            var entity = db.Topics.SingleOrDefault(t => t.Id == updated.Id);
            entity.UpdateFieldsFromRequest(updated);
            db.SaveChanges();
            var result = mapper.Map<TopicResponse>(entity);
            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var topic = db.Topics.SingleOrDefault(t => t.Id == id);
            db.Topics.Remove(topic);
            db.SaveChanges();
            return Ok();
        }

    }
}
