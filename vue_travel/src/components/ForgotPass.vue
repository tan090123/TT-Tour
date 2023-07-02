<template lang="">
  <div class="forgot_pass">
    <h2>Lấy lại mật khẩu</h2>
    <form @submit.prevent="onSubmit">
      <div class="form-group">
        <label for="email">Email:</label>
        <input
          type="text"
          id="email"
          name="email"
          v-model="forgot_email"
          @blue="error_ForgotEmail"
          @input="error_ForgotEmail"
        />
        <span v-if="errorEmail" class="text-danger">{{ errorEmail }}</span>
      </div>
      <div class="form-group">
        <input type="submit" value="Gửi yêu cầu" />
      </div>
    </form>
  </div>  
</template>
<script>
export default {
  data() {
    return {
      forgot_email: "",
      errorEmail: "",
      isForgot: false,
    };
  },
  mounted() {
    const userEmail = localStorage.getItem("userEmail");
    if (userEmail) {
      window.location.href = "/";
    }
  },

  methods: {
    validateEmail(email) {
      const emailRegex =
        /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
      return emailRegex.test(email);
    },
    error_ForgotEmail() {
      if (this.forgot_email.trim() === "") {
        this.errorEmail = "Email không được bỏ trống";
        this.isForgot = false;
      } else if (!this.validateEmail(this.forgot_email)) {
        this.errorEmail = "Email không hợp lệ";
        this.isForgot = false;
      } else {
        this.errorEmail = "";
        this.isForgot = true;
      }
    },

    onSubmit() {
      if (this.isForgot) {
        // eslint-disable-next-line no-undef
        axios
          .post("/api/RegisLogin/forgot-password", {
            email: this.forgot_email,
          })
          .then((response) => {
            // Xử lý kết quả
            const result = response.data.result;
            const errorMessage = response.data.errorMessage;
            if (result) {
              console.table(response.data);
              // eslint-disable-next-line no-undef
              Swal.fire({
                title: "Gửi thành công",
                text: errorMessage + "💜",
                icon: "success",
                confirmButtonText: "OK",
              }).then(() => {
                // Chuyển hướng đến trang chủ
                window.location.href = "/login";
              });
            } else {
              // console.table(response.data);
              // eslint-disable-next-line no-undef
              Swal.fire({
                title: "Lấy mật khẩu thất bại !!",
                text: errorMessage,
                icon: "error",
                confirmButtonText: "OK",
              });
            }
          })
          .catch((error) => {
            // Xử lý lỗi
            console.error(error);
            // eslint-disable-next-line no-undef
            Swal.fire({
              text: "Lấy mật khẩu thất bại  !!",
              icon: "error",
              confirmButtonText: "OK",
            });
          });
      } else {
        // eslint-disable-next-line no-undef
        Swal.fire({
          title: "Vui lòng điền đúng thông tin -.-",
          icon: "warning",
          confirmButtonText: "OK",
        });
      }
    },
  },
};
</script>
<style lang="scss" scoped>
.forgot_pass {
  max-width: 40rem;
  margin: 10rem auto 5rem;
  padding: 2rem;
  background-color: #fff;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);

  h2 {
    text-align: center;
  }

  .form-group {
    margin-bottom: 20px;
  }

  label {
    display: block;
    font-weight: bold;
    margin-bottom: 5px;
  }

  input[type="text"] {
    width: 100%;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
    box-sizing: border-box;
  }

  input[type="submit"] {
    width: 100%;
    padding: 10px;
    background-color: #4caf50;
    color: #fff;
    border: none;
    border-radius: 5px;
    cursor: pointer;
  }
}
</style>
