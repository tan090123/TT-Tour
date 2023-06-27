<template>
  <h1>check</h1>
</template>

<script>
export default {
  name: "TourPayment",
  props: {
    tourID: {
      type: String,
      required: true,
    },
    infoContact: {
      type: Object,
      required: true,
    },
    customers: {
      type: Array,
      required: true,
    },
  },
  mounted() {
    console.log(this.tourID);
    console.log(this.infoContact);
    console.log(this.customers);
  },
};
</script>

<style>
h1 {
  margin-top: 10rem;
}
</style>
