export default class Login {
  constructor(addToApp) {
    document.title = "Todo App Login";

    const view = this.getHtml();
    addToApp(view);

    const formId = "todoapp-form-login";
    this.formElement = document.getElementById(formId);
    console.log(this.formElement);
    // Attach the event listener programmatically and bind 'this'
    this.formElement.addEventListener('submit', (e) => {
      this.doLogin(e);
      //event.preventDefault();
      //console.log('doing login');
    });
  }

  doLogin(event) {
    event.preventDefault();
    console.log('doing login');
  }

  getHtml() {

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