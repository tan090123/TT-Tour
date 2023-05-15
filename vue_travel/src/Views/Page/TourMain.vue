<template>
  <div class="tourMain">
    <div class="tourMain__img">

      <img src="../../assets/banner/banner.jpg" alt="" />
    </div>
    <div class="tourMain__both container shadow">

      <div class="tourMain__both-nav">

        <ul class="nav nav-tabs" id="myTab" role="tablist">
          <li class="nav-item" role="presentation">
            <button class="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#home" type="button"
              role="tab" aria-controls="home" aria-selected="true">
              <i class="fa-solid fa-bus mb-2 fs-3"></i>
              <p>Tour du lịch <br>trọn gói </p>
            </button>
          </li>
          <li class="nav-item" role="presentation">
            <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile" type="button"
              role="tab" aria-controls="profile" aria-selected="false">
              <i class="fa-solid fa-hotel mb-2 fs-3"></i>
              <p>Khách sạn</p>
              <small class="badge btn-danger">Ưu đãi hot</small>
            </button>
          </li>
          <li class="nav-item" role="presentation">
            <button class="nav-link" id="messages-tab" data-bs-toggle="tab" data-bs-target="#messages" type="button"
              role="tab" aria-controls="messages" aria-selected="false">
              <i class="fa-solid fa-jet-fighter-up mb-2 fs-3"></i>
              <p>Vé máy bay</p>
            </button>
          </li>
          <li class="nav-item" role="presentation">
            <button class="nav-link" id="settings-tab" data-bs-toggle="tab" data-bs-target="#settings" type="button"
              role="tab" aria-controls="settings" aria-selected="false">
              <div class="d-flex">
                <i class="fa-solid fa-jet-fighter-up me-2 fs-3"></i>
                <p>+</p>
                <i class="fa-solid fa-hotel ms-2 fs-3"></i>
              </div>
              <p>Combo</p>
              <p>Vé máy bay + Khách sạn</p>

            </button>
          </li>
          <li class="nav-item" role="presentation">
            <button class="nav-link" id="carAndres-tab" data-bs-toggle="tab" data-bs-target="#carAndres" type="button"
              role="tab" aria-controls="carAndres" aria-selected="false">
              <div class="d-flex">
                <i class="fa-solid fa-car me-2 fs-3"></i>
                <p>+</p>
                <i class="fa-solid fa-hotel ms-2 fs-3"></i>
              </div>
              <p>Combo</p>
              <p>Xe + Khách sạn</p>

            </button>
          </li>
          <li class="nav-item" role="presentation">
            <button class="nav-link" id="search-tab" data-bs-toggle="tab" data-bs-target="#search" type="button"
              role="tab" aria-controls="search" aria-selected="false">
              <i class="fa-solid fa-magnifying-glass mb-2 fs-3"></i>
              <p>Tra cứu Booking</p>
            </button>
          </li>
        </ul>
      </div>

      <div class="tourMain__both-tab">
        <div class="tab-content">
          
          <div class="tab-pane active" id="home" role="tabpanel" aria-labelledby="home-tab">
            <div class="p-4">

              <div class="tab-nav">
                <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                  <li class="nav-item me-3" role="presentation">
                    <button class="nav-link dltn active" id="pills-home-tab" data-bs-toggle="pill"
                      data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home"
                      aria-selected="true">
                      Du lịch trong nước
                    </button>
                  </li>
                  <li class="nav-item" role="presentation">
                    <button class="nav-link dlnn" id="pills-profile-tab" data-bs-toggle="pill"
                      data-bs-target="#pills-profile" type="button" role="tab" aria-controls="pills-profile"
                      aria-selected="false">
                      Du lịch nước
                      ngoài
                    </button>
                  </li>
                </ul>
              </div>
              
            </div>
          </div>

          <div class="tab-pane" id="profile" role="tabpanel" aria-labelledby="profile-tab">
            this í 2
          </div>
          <div class="tab-pane" id="messages" role="tabpanel" aria-labelledby="messages-tab">
            3
          </div>
          <div class="tab-pane" id="settings" role="tabpanel" aria-labelledby="settings-tab">
            4
          </div>
          <div class="tab-pane" id="carAndres" role="tabpanel" aria-labelledby="carAndres-tab">
            5
          </div>
          <div class="tab-pane" id="search" role="tabpanel" aria-labelledby="search-tab">
            6
          </div>
        </div>

      </div>
    </div>

  </div>
</template>
  
<script>
import "@/scss/_tourMain.scss";
export default {
  name: "tourMain-component",
};
</script>
  
<style></style>