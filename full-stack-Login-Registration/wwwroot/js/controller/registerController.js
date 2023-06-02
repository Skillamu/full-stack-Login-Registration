async function registerBtn() {
    model.inputs.register.username = document.getElementById("username").value;
    model.inputs.register.password = document.getElementById("password").value;
    model.inputs.register.confirmPassword = document.getElementById("confirmPassword").value;

    const response = await fetch("/register", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(model.inputs.register)
    });

    if (response.status == 201) {
        model.currentView = "login";
        viewHandler();
    }
    else if (response.status == 409) {
        console.error("Username is already taken.");
    }
    else {
        console.error("Invalid inputs.");
    }
}