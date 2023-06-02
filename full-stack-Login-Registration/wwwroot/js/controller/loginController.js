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
        model.loggedInUser = await response.json();
        model.currentView = "homepage";
        viewHandler();
    }
    else {
        console.error("Invalid credentials.");
    }
}