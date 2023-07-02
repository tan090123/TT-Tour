<template lang="">
    <div class="password-change-form">
  <h2>Thay đổi mật khẩu</h2>
  <form @submit.prevent="changePassword">
    <div class="form-group">
      <label for="old-password">Mật khẩu cũ:</label>
      <div class="password-input">
        <input :type="showOldPassword ? 'text' : 'password'" v-model="oldPassword" required>
      <i
          class="toggle-password"
          :class="showOldPassword ? 'fa fa-eye-slash' : 'fa fa-eye'"
          @click="toggleShowOldPassword"
        ></i>
      </div>
    </div>
    <div class="form-group">
      <label for="new-password">Mật khẩu mới:</label>
      <div class="password-input">
        <input
          :type="showNewPassword ? 'text' : 'password'"
          v-model="newPassword"
          required
        >
        <i
          class="toggle-password"
          :class="showNewPassword ? 'fa fa-eye-slash' : 'fa fa-eye'"
          @click="toggleShowNewPassword"
        ></i>
      </div>
    </div>
    <div class="form-group">
      <label for="confirm-password">Xác nhận mật khẩu mới:</label>
      <div class="password-input">
        <input
          :type="showConfirmPassword ? 'text' : 'password'"
          v-model="confirmPassword"
          required
        >
        <i
          class="toggle-password"
          :class="showConfirmPassword ? 'fa fa-eye-slash' : 'fa fa-eye'"
          @click="toggleShowConfirmPassword"
        ></i>
      </div>
    </div>
    <button type="submit">Thay đổi mật khẩu</button>
  </form>
</div>


</template>
<script>
export default {
    name: 'AppPassWord',
    data() {
    return {
      oldPassword: '',
      newPassword: '',
      confirmPassword: '',
      showOldPassword: false,
      showNewPassword: false,
      showConfirmPassword: false
    };
  },
  methods: {
    changePassword() {
    //   if (this.newPassword !== this.confirmPassword) {
    //     alert("Mật khẩu mới và xác nhận mật khẩu mới không khớp!");
    //     return;
    //   }

      var userId = localStorage.getItem('userID');
      console.log(userId);
      // eslint-disable-next-line
      axios
        .put(`/api/User/changepassword/${userId}`, {
          password: this.oldPassword,
          newPassword: this.newPassword,
          confirmNewPassword: this.confirmPassword
        })
        .then((response) => {
            const result = response.data.result;
          if(result) {
            // eslint-disable-next-line no-undef
                    Swal.fire({
                        title: 'Thay đổi mật khẩu thành công!',
                        icon: 'success',
                        confirmButtonText: 'OK',
                    }).then(() => {
                        window.location.href = '/';
                    })
          } else {
            const errorMessage = response.data.errorMessage;
              console.table(response.data);
              // eslint-disable-next-line no-undef
              Swal.fire({
                title: "Thay đổi mật khẩu thất bại !!",
                text: errorMessage,
                icon: "error",
                confirmButtonText: "OK",
              });
          }
        })
        .catch((error) => {
          // Xử lý lỗi
          alert("Thay đổi mật khẩu thất bại!");
          console.log(error);
        });
    },
    toggleShowOldPassword() {
        this.showOldPassword = !this.showOldPassword;
    },
    toggleShowNewPassword() {
      this.showNewPassword = !this.showNewPassword;
    },
    toggleShowConfirmPassword() {
      this.showConfirmPassword = !this.showConfirmPassword;
    }
  }
}
</script>
<style lang="scss" scoped>
.password-change-form {
    max-width: 400px;
    margin: 9rem auto 5rem;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 5px;

}

.password-change-form h2 {
    text-align: center;
    margin-bottom: 20px;
    font-size: 2.7rem;
}

.form-group {
    margin-bottom: 15px;
}

.form-group label {
    display: block;
    font-weight: bold;
}

.form-group input[type="password"],
.form-group input[type="text"] {
    width: 100%;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 3px;
}
.password-input {
  position: relative;
  i {
    font-size: 1.8rem;
  }
}

.password-input input {
  padding-right: 30px;
}

.password-input .toggle-password {
  position: absolute;
  top: 50%;
  right: 10px;
  transform: translateY(-50%);
  cursor: pointer;
  color: #999;
  transition: color 0.3s;
}

.password-input .toggle-password:hover {
  color: #555;
}


button[type="submit"] {
    display: block;
    width: 100%;
    padding: 10px;
    background-color: #007bff;
    color: #fff;
    border: none;
    border-radius: 3px;
    cursor: pointer;
}

button[type="submit"]:hover {
    background-color: #0056b3;
}
</style>