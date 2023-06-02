function loginView() {
    const app = document.getElementById("app");

    app.innerHTML = `
    <h2>Login</h2>

    <label for="username">Username</label>
    <input type="text" id="username"> <br>

    <label for="password">Password</label>
    <input type="password" id="password"> <br>

    <button onclick="loginBtn()">Login</button>

    <p>Don't have an account yet? <span onclick="changeCurrentView('register')">Register</span></p>
    `
};