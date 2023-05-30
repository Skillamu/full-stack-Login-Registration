// Model
const model = {
    inputs: {
        login: {
            username: "",
            password: ""
        },
        register: {
            username: "",
            password: "",
            confirmPassword: ""
        }
    }
}

// View
registerView();
function registerView() {
    const app = document.getElementById("app");

    app.innerHTML = `
    <h2>Register</h2>

    <button onclick="loginView()">Login page</button>

    <label for="username">Username</label>
    <input type="text" id="username"> <br>

    <label for="password">Password</label>
    <input type="password" id="password"> <br>

    <label for="confirmPassword">Confirm password</label>
    <input type="password" id="confirmPassword"> <br>

    <button onclick="registerBtn()">Register</button>
    `
};

function loginView() {
    const app = document.getElementById("app");

    app.innerHTML = `
    <h2>Login</h2>

    <label for="username">Username</label>
    <input type="text" id="username"> <br>

    <label for="password">Password</label>
    <input type="password" id="password"> <br>

    <button onclick="loginBtn()">Login</button>
    `
};

function homePageView() {
    const app = document.getElementById("app");

    app.innerHTML = `
    <h2>Homepage</h2>

    <p>Hello ${model.inputs.login.username} :)</p>
    `
}

// Controller
async function registerBtn() {
    const usernameInput = document.getElementById("username").value;
    const passwordInput = document.getElementById("password").value;
    const confirmPasswordInput = document.getElementById("confirmPassword").value;

    model.inputs.register.username = usernameInput;
    model.inputs.register.password = passwordInput;
    model.inputs.register.confirmPassword = confirmPasswordInput;

    const response = await fetch("/register", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(model.inputs.register)
    });

    if (response.status == 201) {
        loginView();
    }
    else if (response.status == 409) {
        console.error("username is already taken.");
    }
    else {
        console.error("invalid inputs");
    }
}

async function loginBtn() {
    const usernameInput = document.getElementById("username").value
    const passwordInput = document.getElementById("password").value

    model.inputs.login.username = usernameInput;
    model.inputs.login.password = passwordInput;

    const response = await fetch("/login", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(model.inputs.login)
    });

    if (response.status == 200) {
        homePageView();
    }
    else {
        console.error("invalid credentials");
    }
}