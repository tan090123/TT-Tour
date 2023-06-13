<template lang="">
  <div class="create-tour">
    <div class="container-fluid">
      <h2 class="tour-title text-center">Tạo danh sách Tour</h2>
      <form @submit.prevent="onSubmit">
        <div class="form-group">
          <label for="code">Code:</label>
          <input type="text" id="code" name="tourCode" v-model="tourCode" />
        </div>
        <div class="form-group">
          <label for="name">Name:</label>
          <input type="text" id="name" name="tourName" v-model="tourName" />
        </div>
        <div class="form-group">
          <label for="upload">Upload Image:</label>
          <input
            type="file"
            id="upload"
            name="upload"
            @change="handleFileChange"
          />
        </div>
        <div class="form-group">
          <label for="departure">Departure:</label>
          <input
            type="text"
            id="departure"
            name="departure"
            v-model="departure"
          />
        </div>
        <div class="form-group">
          <label for="destination">Destination:</label>
          <input
            type="text"
            id="destination"
            name="destination"
            v-model="destination"
          />
        </div>
        <div class="form-group">
          <label for="description">Description:</label>
          <textarea
            id="description"
            name="description"
            v-model="description"
          ></textarea>
        </div>
        <div class="form-group">
          <label for="price">Price:</label>
          <input type="number" id="price" name="price" v-model="price" />
        </div>
        <div class="form-group">
          <label for="promotionPrice">Promotion Price:</label>
          <input
            type="number"
            id="promotionPrice"
            name="promotionPrice"
            v-model="promotionPrice"
          />
        </div>
        <div class="form-group">
          <label for="discountTour">Discount Tour:</label>
          <input
            type="text"
            id="discountTour"
            name="discountTour"
            v-model="discountTour"
          />
        </div>
        <div class="form-group">
          <label for="checkinDays">Checkin Days:</label>
          <input
            type="datetime-local"
            id="checkinDays"
            name="checkinDays"
            v-model="tourCheckinDays"
          />
        </div>
        <div class="form-group">
          <label for="checkoutDays">Checkout Days:</label>
          <input
            type="datetime-local"
            id="checkoutDays"
            name="checkoutDays"
            v-model="tourCheckoutDays"
          />
        </div>
        <div class="form-group">
          <label for="totalSit">Total Sit:</label>
          <input
            type="number"
            id="totalSit"
            name="totalSit"
            v-model="tourTotalSit"
          />
        </div>
        <div class="form-group">
          <label for="availableSit">Available Sit:</label>
          <input
            type="number"
            id="availableSit"
            name="availableSit"
            v-model="tourAvailableSit"
          />
        </div>
        <div class="form-group">
          <label for="type">Type:</label>
          <select id="type" name="type" v-model="tourType">
            <option
              v-for="tintype in types"
              :value="tintype.typeID"
              :key="tintype.typeID"
            >
              {{ `${tintype.typeID} - ${tintype.typeName}` }}
            </option>
          </select>
        </div>
        <button type="submit">Submit</button>
      </form>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      tourCode: "",
      tourName: "",
      departure: "",
      destination: "",
      description: "",
      price: "",
      promotionPrice: "",
      discountTour: "",
      tourCheckinDays: "",
      tourCheckoutDays: "",
      tourTotalSit: "",
      tourAvailableSit: "",
      tourType: "",
      file: null,
      types: [],
    };
  },
  mounted() {
    this.fetchDataType();
  },
  methods: {
    fetchDataType() {
      // eslint-disable-next-line
      axios
        .get("/api/TourType")
        .then((response) => {
          // handle success
          this.types = response.data;
        })
        .catch((error) => {
          // handle error
          console.log(error);
        });
    },
    onSubmit() {
      this.onCreateTour();
    },
    handleFileChange(event) {
      this.file = event.target.files[0];
    },

    onCreateTour() {
      const fileInput = document.getElementById("upload");
      const file = fileInput.files[0];
      const fileName = file.name; // Lấy tên file
      // eslint-disable-next-line
      axios
        .post("/api/Tour", {
          tourCode: this.tourCode,
          tourName: this.tourName,
          departure: this.departure,
          destination: this.destination,
          description: this.description,
          price: this.price,
          promotionPrice: this.promotionPrice,
          discountTour: this.discountTour,
          tourCheckinDays: this.tourCheckinDays,
          tourCheckoutDays: this.tourCheckoutDays,
          tourTotalSit: this.tourTotalSit,
          tourAvailableSit: this.tourAvailableSit,
          tourType: this.tourType,
          tourimage: fileName,
        })
        .then((response) => {
          // Xử lý kết quả thành công
          console.table(response.data);
          // eslint-disable-next-line no-undef
          Swal.fire({
            title: "Thông báo thành công!",
            text: "Bạn đã tạo thành công thông báo xịn xò!",
            icon: "success",
            confirmButtonText: "OK",
          });
          // Chuyển hướng đến trang danh sách tour
          window.location.href = "/admin/tour";
        })
        .catch((error) => {
          // Xử lý lỗi
          console.error(error);
          // eslint-disable-next-line no-undef
          Swal.fire({
            title: "Thất bại",
            text: "Bạn đã sửa thất bại!!!",
            icon: "error",
            confirmButtonText: "OK",
          });
        });
    },
  },
};
</script>
<style lang="scss">
.create-tour {
  margin-bottom: 3rem;
}

.form-group {
  margin-bottom: 15px;
}

.tour-title {
  font-size: 3rem;
  font-weight: 600;
  padding: 2rem 0;
}

label {
  display: block;
  font-weight: bold;
  margin-bottom: 1rem;
}

form {
  margin: 0 5rem;
}

input[type="text"],
input[type="number"],
textarea,
select {
  width: 100%;
  padding: 5px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

button[type="submit"] {
  padding: 10px 20px;
  background-color: #4caf;
}
</style>
