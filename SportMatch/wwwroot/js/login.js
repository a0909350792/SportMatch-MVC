window.onload = function () {
    const modal = document.getElementById("loginModal");
    modal.style.display = "none";
    modal.classList.remove("show");
};

// 打開登入模態框
function openLoginModal() {
    const modal = document.getElementById("loginModal");
    modal.style.display = "flex";
    document.body.style.overflow = "hidden";
    document.body.style.position = "fixed";
    document.body.style.width = "100%";
}

// 關閉登入模態框
function closeModal() {
    const modal = document.getElementById("loginModal");
    modal.style.display = "none";
    document.body.style.overflow = "auto";
    document.body.style.position = "";
    document.body.style.width = "";
}

// 登出功能
function logout() {
    localStorage.removeItem("loggedInEmail");
    location.reload();
}

// 監聽登入表單提交
const loginForm = document.getElementById("loginForm");

loginForm.addEventListener("submit", async function (e) {
    e.preventDefault(); // 防止表單提交

    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const remember = document.getElementById("remember").checked;

    // 確認傳送的資料
    console.log("傳送的資料：", {
        email: email,
        password: password,
        remember: remember
    });

    const errorMessageElement = document.querySelector(".error-message");
    errorMessageElement.style.display = "none"; // 清除之前的錯誤訊息

    try {
        const response = await fetch('/Account/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                email: email,
                password: password,
                remember: remember
            }),
        });

        // 確認後端回應格式為 JSON
        const result = await response.json(); // 解析回應 JSON
        console.log("後端回應結果:", result);

        if (response.ok && result.success) {
            // 登入成功
            if (remember) {
                localStorage.setItem("savedEmail", email);
            } else {
                localStorage.removeItem("savedEmail");
            }

            localStorage.setItem("loggedInEmail", email);
            updateUIAfterLogin(email);

            closeModal();
            alert("登入成功！");
        } else {
            // 登入失敗
            if (errorMessageElement) {
                errorMessageElement.textContent = result.message || "帳號或密碼錯誤，請重新嘗試。";
                errorMessageElement.style.display = "block";
            }
        }
    } catch (error) {
        console.error('登入過程中發生錯誤:', error);
        const errorMessageElement = document.querySelector(".error-message");
        if (errorMessageElement) {
            errorMessageElement.textContent = "登入過程中發生錯誤，請稍後再試。";
            errorMessageElement.style.display = "block";
        }
    }
});



// 更新登入後的 UI 顯示
function updateUIAfterLogin(email) {
    document.querySelector(".btn-login").style.display = "none";
    document.querySelector(".btn-register").style.display = "none";

    let userEmailContainer = document.querySelector(".user-email-container");
    if (!userEmailContainer) {
        userEmailContainer = document.createElement("div");
        userEmailContainer.classList.add("user-email-container");

        const userEmail = document.createElement("span");
        userEmail.classList.add("user-email");

        const dropdownContent = document.createElement("div");
        dropdownContent.classList.add("dropdown-content");

        const profileLink = document.createElement("a");
        profileLink.href = "#profile";
        profileLink.textContent = "個人資料";

        const cartLink = document.createElement("a");
        cartLink.href = "#cart";
        cartLink.textContent = "購物車清單";

        const favoritesLink = document.createElement("a");
        favoritesLink.href = "#favorites";
        favoritesLink.textContent = "收藏清單";

        const logoutButton = document.createElement("button");
        logoutButton.textContent = "登出";
        logoutButton.classList.add("btn-logout");
        logoutButton.onclick = function () {
            localStorage.removeItem("loggedInEmail");
            location.reload();
        };

        dropdownContent.appendChild(profileLink);
        dropdownContent.appendChild(cartLink);
        dropdownContent.appendChild(favoritesLink);
        dropdownContent.appendChild(logoutButton);
        userEmailContainer.appendChild(userEmail);
        userEmailContainer.appendChild(dropdownContent);
        document.querySelector(".user-actions").appendChild(userEmailContainer);
    }

    document.querySelector(".user-email").textContent = email;
}

// 密碼顯示/隱藏邏輯
const togglePassword = document.querySelector(".toggle-password");
const passwordInput = document.getElementById("password");

togglePassword.addEventListener("click", function () {
    const type = passwordInput.getAttribute("type") === "password" ? "text" : "password";
    passwordInput.setAttribute("type", type);
    this.querySelector("i").classList.toggle("fa-eye");
    this.querySelector("i").classList.toggle("fa-eye-slash");
});

// 自動填充帳號
const savedEmail = localStorage.getItem("savedEmail");
if (savedEmail) {
    document.getElementById("email").value = savedEmail;
    document.getElementById("remember").checked = true;
}

// 顯示當前登錄的帳號
const loggedInEmail = localStorage.getItem("loggedInEmail");
if (loggedInEmail) {
    updateUIAfterLogin(loggedInEmail);
}
