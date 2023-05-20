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

    <label for="username">Username:</label>
    <input type="text" id="username"> <br>

    <label for="password">Password:</label>
    <input type="password" id="password"> <br>

    <button onclick="loginBtn()">Login</button>
    `
};

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
}

async function loginBtn() {
    // ...
}