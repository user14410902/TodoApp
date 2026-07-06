// source: dcode Build a Single Page Application with JavaScript(No Frameworks)
// https://www.youtube.com/watch?v=6BozpmSjk-Y&list=PLw5h0DiJ-9PBXb6SnjLxAQH6ecMYz3Wjs

import AllTodos from "./views/AllTodos.js";
import Login from "./views/Login.js";

const router = async () => {

  console.log(`routing ${location.pathname}`);

  const routes = [
    { path: "/login", view: Login },
    { path: "/", view: AllTodos }
  ];

  const match = routes.find(r => r.path === location.pathname);

  if (match === null) {
    match = routes[0];
  }

  console.log(match);

  const view = new match.view();
  document.querySelector("#app").innerHTML = await view.getHtml();
}

window.addEventListener("popstate", router);//call return when going back in history

document.addEventListener("DOMContentLoaded", () => {

  document.body.addEventListener("click", e => {
    if (e.target.matches("[data-link")) {
      e.preventDefault();
      navigateTo(e.target.href);
    }
  });

  router();
});