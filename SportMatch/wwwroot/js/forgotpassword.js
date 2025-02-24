document.getElementById("sendTempPasswordButton").addEventListener("click", function () {
    var email = document.getElementById("email").value;

    if (email) {
        // 發送請求到後端 API 來處理生成臨時密碼
        fetch('/ForgotPassword/SendTempPassword', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email: email })
        })
            .then(response => response.json().then(data => ({ status: response.status, body: data })))
            .then(result => {
                if (result.status === 200) {
                    document.getElementById("tempPassword").innerText = "您的臨時密碼是: " + result.body.tempPassword;
                } else {
                    document.getElementById("tempPassword").innerText = result.body.message || "發生錯誤，請稍後再試。";
                }
            })
            .catch(error => {
                document.getElementById("tempPassword").innerText = "發生錯誤，請稍後再試。";
                console.error("Request failed: ", error);
            });
    }
});

