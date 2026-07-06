export default class AllTodos {
  constructor(addToApp) {
    document.title = "All Todos";

    const view = getHtml();
    addToApp(view);
  }

  async getHtml() {


    // const authResponse = await fetch("/api/callmefirst", {
    //   method: "post",
    //   headers: {
    //     "X-Api-Version": "1.0"
    //   }
    // });
    // console.log(authResponse);
    // const jsonResponse = await authResponse.json();
    // const token = jsonResponse.token;
    // console.log(jsonResponse);

    const token = document.token;

    const response = await fetch("api/todos", {
      method: "get",
      headers: {
        "X-Api-Version": "1.0",
        "Authorization": `Bearer ${token}`,
        "Content-Type": 'application/json'
      }
    });

    const result = await response.json();

    let html = `<h2>All Todos</h2>
    <ul>`;

    for (const todo of result) {
      html += `<li>${todo.name}</li>`;
    }
    html += `
    </ul>`

    return html;
  }
}