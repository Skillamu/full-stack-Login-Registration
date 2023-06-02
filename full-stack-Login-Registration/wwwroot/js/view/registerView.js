function registerView() {
    const app = document.getElementById("app");

    app.innerHTML = `
    <h2>Register</h2>

    <label for="username">Username</label>
    <input type="text" id="username"> <br>

    <label for="password">Password</label>
    <input type="password" id="password"> <br>

    <label for="confirmPassword">Confirm password</label>
    <input type="password" id="confirmPassword"> <br>

    <button onclick="registerBtn()">Register</button>

    <p>Already have an account? <span onclick="changeCurrentView('login')">Login</span></p>
    `
};