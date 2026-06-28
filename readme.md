# Introduction
This is my boring Todo app to showcase my skills.

It is work in progress. Time permitting I will keep adding features and stuff to show off what I can do. So this app will never be finished.

# The Todo App's Todo List
## Overall Aims
Ideally my aim is to have
1. unit tests
1. a front end (minimal but also fancy using a well know framework)
1. a back-end API
1. database
1. scripts
1. devops automation
1. add fluent validation

## Tidy Up Todos
1. fixing / tidy up versioning
1. fix openapi / swagger confusion

# Git branches

## dev
Working development branch

## development/...
All development work goes here

... more branches to come ...

# Useful Urls and Curl Commands

(Replace localhost:5285 with the correct server and port.)

**Web UI** http://localhost:5285/
**OpenApi** http://localhost:5285/openapi/v1.json
**Swagger** http://localhost:5285/swagger/index.html#/Api

## API

**Get all todos** http://localhost:5285/api/v1/todos
curl -X GET http://localhost:5285/api/v1/todos

**Create a todo** http://localhost:5285/api/v1/todos/create
curl -X POST --json '{"name":"New Todo","description":"Description of new todo", "completed":false, "created":"2026-06-27", "dueBy":"2026-07-01"}' http://localhost:5285/api/v1/todos/create
