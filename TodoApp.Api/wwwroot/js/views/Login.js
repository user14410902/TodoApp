export default class Login {
  constructor() {
    document.title = "Todo App Login";


  }

  async doPostConstructLoad(addToApp) {
    const view = await this.getHtml();
    addToApp(view);

    const formId = "todoapp-form-login";
    this.formElement = document.getElementById(formId);
    console.log(this.formElement);
    // Attach the event listener programmatically and bind 'this'
    this.formElement.addEventListener('submit', async (e) => {
      await this.doLogin(e);
      //event.preventDefault();
      //console.log('doing login');
    });
  }

  async doLogin(event) {
    event.preventDefault();
    console.log('doing login');

    const username = document.getElementById("username").value;
    const password = document.getElementById("password").value;

    const authResponse = await fetch("/api/login", {
      method: "post",
      headers: {
        "Accept": "application/json",
        "Content-Type": "application/json",
        "X-Api-Version": "1.0"
      },
      body: JSON.stringify({ username, password })
    });
    console.log(authResponse);
    const jsonResponse = await authResponse.json();
    const token = jsonResponse.token;
    console.log(jsonResponse);

    sessionStorage.setItem("token", token);

    console.log(document.token);

    window.location.replace("/")
  }

  async getHtml() {

    let html = `<h2>Login</h2>
   <form id="todoapp-form-login">
  <label for="username">Username</label>
  <input type="text" id="username" name="username" required />

  <label for="password">Password</label>
  <input type="password" id="password" name="password" required />

  <button type="submit">Login</button>
</form>`

    return html;
  }
}