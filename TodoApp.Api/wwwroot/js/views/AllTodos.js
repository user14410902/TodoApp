export default class AllTodos {
  constructor() {
    document.title = "All Todos";
  }

  async getHtml() {

    const response = await fetch("api/todos");
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