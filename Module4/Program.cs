using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module4.Data;
using Module4.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();

builder.Services.AddDbContext<ToDoContext>(options => options.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
SeedData.Seed(app);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/todoitems", GetAll);
app.MapGet("/todoitems/complete", GetAllComplete);
app.MapGet("/todoitems/{id}", GetById);
app.MapPost("/todoitems", PostAsync);
app.MapPut("/todoitems/{id}", PutAsync);
app.MapDelete("/todoitems/{id}",DeleteAsync);

app.Run();

static async Task<IResult> GetAll(ToDoContext _context)
{
    return Results.Ok(await _context.ToDoItems.ToListAsync());
}

static async Task<IResult> GetAllComplete(ToDoContext _context)
{
    return Results.Ok(await _context.ToDoItems.Where(x => x.IsComplete).ToListAsync());
}

static async Task<IResult> GetById(int id, ToDoContext _context)
{
    var todoItem = await _context.ToDoItems.FindAsync(id);
    if (todoItem != null)
        return Results.Ok(todoItem);
    else
        return Results.NotFound();
}

static async Task<IResult> PostAsync(ToDoContext _context, [FromBody]ToDoItemRequest request)
{
    var TodoItem = new ToDoItem
    {
        Name = request.Name,
        IsComplete = request.IsComplete,
    };
    _context.ToDoItems.Add(TodoItem);
    await _context.SaveChangesAsync();
    return Results.Created($"/todoitems/{TodoItem.Id}", TodoItem);
}
static async Task<IResult> PutAsync(int id, ToDoContext _context, [FromBody] ToDoItemRequest request)
{
    var todoItem = await _context.ToDoItems.FindAsync(id);
    if (todoItem == null)
        return Results.NotFound();
    todoItem.Name = request.Name;
    todoItem.IsComplete = request.IsComplete;
    _context.ToDoItems.Update(todoItem);
    await _context.SaveChangesAsync();
    return Results.Created($"/todoitems/{id}", request);
}

static async Task<IResult> DeleteAsync(int id, ToDoContext _context)
{
    var todoItem = await _context.ToDoItems.FindAsync(id);
    if (todoItem == null)
        return Results.NotFound();
    _context.ToDoItems.Remove(todoItem);
    await _context.SaveChangesAsync();
    return Results.Ok(todoItem);
}

