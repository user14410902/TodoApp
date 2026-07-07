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
1. refactor API into 2 projects: API and UI
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

**Web UI** `http://localhost:5285/`
**OpenApi** `http://localhost:5285/openapi/v1.json`
**Swagger** `http://localhost:5285/swagger/index.html#/Api`

## API

Use Swagger! `http://localhost:5285/swagger/index.html#/`

**Authentication related**

`http://localhost:5285/api/login`

`curl -X POST --header "X-Api-Version: 1.0" --header "Accept: application/json" --header "Content-Type: application/json" --data '{"username":"xyz","password":"xyz"}' http://localhost:5285/api/login`

**Get all todos**

`http://localhost:5285/api/todos`

`curl -X GET --header "X-Api-Version: 1.0" --header "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3ODM0Mzc1MDQsImlhdCI6MTc4MzM1MTEwNCwiVXNlck5hbWUiOiJVc2VybmFtZSIsIlVzZXJJZCI6IjAwMSIsInJvbGUiOlsiTWFuYWdlciIsIkF1ZGl0b3IiXSwibmJmIjoxNzgzMzUxMTA0fQ.URW36rsY0dZ2HIvqpwwy-8rsdgA-gqShT9Pt7S7Tfiw" http://localhost:5285/api/todos`

### Diagnostics
#### Test Exception Handling
`curl --header "X-Api-Version: 1.0" -X GET http://localhost:5285/api/diagnostics/exception --verbose`

#### Test NotFoundException Handling
`curl --header "X-Api-Version: 1.0" -X GET http://localhost:5285/api/diagnostics/notfoundexception --verbose`


#### Badrequest
`curl --header "X-Api-Version: 1.0" -X GET http://localhost:5285/api/diagnostics/badrequest --verbose`

## Todos
### Get all todos

`http://localhost:5285/api/todos`

`curl --header "X-Api-Version: 1.0" -X GET http://localhost:5285/api/todos --verbose`

### Create a todo

`http://localhost:5285/api/todos/create`

`curl -X POST --json '{"name":"New Todo","description":"Description of new todo", "completed":false, "created":"2026-06-27", "dueBy":"2026-07-01"}' http://localhost:5285/api/todos/create`
