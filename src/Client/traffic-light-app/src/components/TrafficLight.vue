<template>
    <div class="traffic-light">
      <div class="light" :class="{ red: isLightActive(0) }"></div>
      <div class="light" :class="{ yellow: isLightActive(1) }"></div>
      <div class="light" :class="{ green: isLightActive(2) }"></div>
      <div class="elapsed-time">{{ elapsedTime }}</div>
    </div>
  </template>
  
  <script>
  export default {
    props: {
      direction: Number, // Add the direction prop here (e.g., 'north', 'south', 'east', 'west')
      lights: Array,
    },
    computed: {
        elapsedTime() {
        if (this.lights) {
            const matchingLight = this.lights.find(
            (light) => light.direction === this.direction);
            if (matchingLight) {
                return matchingLight.elapsedTime;
            }
        }
        return '-'; 
        },
    },
    methods: {
      isLightActive(color) {
        if (this.lights) {
        const matchingLight = this.lights.find(
          (light) => light.direction === this.direction
        );
        return matchingLight && matchingLight.state === color;
        }
        return false; 
      },
    },
  };
  </script>
  
  <style scoped>
  .traffic-light {
    display: flex;
    flex-direction: column;
    align-items: center;
    border: 3px solid #333;
    /* justify-content: space-evenly; */
    padding: 5px;
    border-radius: 5px;
    background-color: #222;
  }
  
  .light {
    width: 30px;
    height: 30px;
    margin: 5px;
    border-radius: 50%;
    /* filter: grayscale(1); */
    background-color: gray;
    border: dotted 1px;
    background-size: 3px 3px;
    background-image: radial-gradient(gray, transparent);
    transition: background-color 1s;
  }
  
  .red {

    background-color: red;
    /* animation: 13s red infinite; */
    box-shadow: 0 0 3px #111 inset, 0 0 10px red;
    border: dotted 1px red;
    background-image: radial-gradient(brown, transparent);
    /* background-size: 5px 5px; */
    /* width: 100px;
    height: 100px; */
    /* border-radius: 50%;  */
    /* position: absolute; */
    /* top: 20px; */
    /* left: 35px; */
    
  }
  
  .yellow {
    background-color: yellow;
    /* animation: 13s yellow infinite; */
    border: dotted 1px yellow;
    background-image: radial-gradient(orange, transparent);
    box-shadow: 0 0 3px #111 inset, 0 0 10px yellow;
  }
  
  .green {
    background-color: lime;
    /* animation: 13s green infinite; */
    border: dotted 1px lime;
    background-image: radial-gradient(lime, transparent);
    box-shadow: 0 0 3px #111 inset, 0 0 10px lime;
  }
  .elapsed-time {
    color: white;
  }
  </style>
  