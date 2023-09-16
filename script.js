const navSlide = () => {
  const burger = document.querySelector(".burger");
  const nav = document.querySelector(".nav-links");
  const navLinks = document.querySelectorAll(".nav-links a");

  burger.addEventListener("click", () => {
    nav.classList.toggle("nav-active");

    navLinks.forEach((link, index) => {
      if (link.style.animation) {
        link.style.animation = "";
      } else {
        link.style.animation = `navLinkFade 0.5s ease forwards ${
          index / 7 + 0.5
        }s `;
      }
    });
    burger.classList.toggle("toggle");
  });
  //
};

const langs = [
	"Hello World",
	"مرحبا بالعالم",
	"Salam Dünya",
	"Прывітанне Сусвет",
	"Здравей свят",
	"ওহে বিশ্ব",
	"Zdravo svijete",
	"Hola món",
	"Kumusta Kalibutan",
	"Ahoj světe",
	"Helo Byd",
	"Hej Verden",
	"Hallo Welt",
	"Γειά σου Κόσμε",
	"Hello World",
	"Hello World",
	"Hola Mundo",
	"Tere, Maailm",
	"Kaixo Mundua",
	"سلام دنیا",
	"Hei maailma",
	"Bonjour le monde",
	"Dia duit an Domhan",
	"Ola mundo",
	"હેલો વર્લ્ડ",
	"Sannu Duniya",
	"नमस्ते दुनिया",
	"Hello World",
	"Pozdrav svijete",
	"Bonjou Mondyal la",
	"Helló Világ",
	"Բարեւ աշխարհ",
	"Halo Dunia",
	"Ndewo Ụwa",
	"Halló heimur",
	"Ciao mondo",
	"שלום עולם",
	"こんにちは世界",
	"Hello World",
	"Გამარჯობა მსოფლიო",
	"Сәлем Әлем",
	"សួស្តី​ពិភពលោក",
	"ಹಲೋ ವರ್ಲ್ಡ್",
	"안녕하세요 월드",
	"Ciao mondo",
	"ສະ​ບາຍ​ດີ​ຊາວ​ໂລກ",
	"Labas pasauli",
	"Sveika pasaule",
	"Hello World",
	"Kia Ora",
	"Здраво свету",
	"ഹലോ വേൾഡ്",
	"Сайн уу",
	"हॅलो वर्ल्ड",
	"Hai dunia",
	"Hello dinja",
	"မင်္ဂလာပါကမ္ဘာလောက",
	"नमस्कार संसार",
	"Hallo Wereld",
	"Hei Verden",
	"Moni Dziko Lapansi",
	"ਸਤਿ ਸ੍ਰੀ ਅਕਾਲ ਦੁਨਿਆ",
	"Witaj świecie",
	"Olá Mundo",
	"Salut Lume",
	"Привет, мир",
	"හෙලෝ වර්ල්ඩ්",
	"Ahoj svet",
	"Pozdravljen, svet",
	"Waad salaaman tihiin",
	"Përshendetje Botë",
	"Здраво Свете",
	"Lefatše Lumela",
	"Halo Dunya",
	"Hej världen",
	"Salamu, Dunia",
	"ஹலோ வேர்ல்ட்",
	"హలో వరల్డ్",
	"Салом Ҷаҳон",
	"สวัสดีชาวโลก",
	"Kamusta Mundo",
	"Selam Dünya",
	"Привіт Світ",
	"ہیلو ورلڈ",
	"Salom Dunyo",
	"Chào thế giới",
	"העלא וועלט",
	"Mo ki O Ile Aiye",
	"你好，世界",
	"你好，世界",
	"你好，世界",
	"Sawubona Mhlaba"
];
// hello world in 92 Languages

let charSize = 18;
let fallRate = charSize / 2;
let streams;

// -------------------------------
class Char {
	constructor(value, x, y, speed) {
		this.value = value;
		this.x = x;
		this.y = y;
		this.speed = speed;
	}

	draw() {
		const flick = random(100);
		// 10 percent chance of flickering a number instead
		if (flick < 10) {
			fill(120, 30, 100);
			text(round(random(9)), this.x, this.y);
		} else {
			text(this.value, this.x, this.y);
		}

		// fall down
		this.y = this.y > height ? 0 : this.y + this.speed;
	}
}

// -------------------------------------
class Stream {
	constructor(text, x) {
		const y = random(text.length * 4);
		const speed = random(2, 10);
		this.chars = [];

		for (let i = text.length; i >= 0; i--) {
			this.chars.push(
				new Char(text[i], x, (y + text.length - i) * charSize, speed)
			);
		}
	}

	draw() {
		fill(120, 100, 100);
		this.chars.forEach((c, i) => {
			// 30 percent chance of lit tail
			const lit = random(100);
			if (lit < 30) {
				if (i === this.chars.length - 1) {
					fill(120, 30, 100);
				} else {
					fill(120, 100, 90);
				}
			}

			c.draw();
		});
	}
}

function createStreams() {
	// create random streams from langs that span the width
	for (let i = 0; i < width; i += charSize) {
		streams.push(new Stream(random(langs), i));
	}
}

function reset() {
	streams = [];
	createStreams();
}

function setup() {
	createCanvas(innerWidth, innerHeight);
	reset();
	frameRate(60);
	colorMode(HSB);
	noStroke();
	textSize(charSize);
	textFont("monospace");
	background(0);
}

function draw() {
	background(0, 0.4);
	streams.forEach((s) => s.draw());
}

function windowResized() {
	resizeCanvas(innerWidth, innerHeight);
	background(0);
	reset();
}

import * as datGui from "https://cdn.skypack.dev/dat.gui@0.7.7";

const state = {
  fps: 60,
  color: "#0f0",
  charset: "0123456789ABCDEF"
};

const gui = new datGui.GUI();
const fpsCtrl = gui.add(state, "fps").min(1).max(120).step(1);
gui.addColor(state, "color");
gui.add(state, "charset");

const canvas = document.getElementById("canvas");
const ctx = canvas.getContext("2d");

let w, h, p;
const resize = () => {
  w = canvas.width = innerWidth;
  h = canvas.height = innerHeight;

  p = Array(Math.ceil(w / 10)).fill(0);
};
window.addEventListener("resize", resize);
resize();

const random = (items) => items[Math.floor(Math.random() * items.length)];

const draw = () => {
  ctx.fillStyle = "rgba(0,0,0,.05)";
  ctx.fillRect(0, 0, w, h);
  ctx.fillStyle = state.color;

  for (let i = 0; i < p.length; i++) {
    let v = p[i];
    ctx.fillText(random(state.charset), i * 10, v);
    p[i] = v >= h || v >= 10000 * Math.random() ? 0 : v + 10;
  }
};

let interval = setInterval(draw, 1000 / state.fps);
fpsCtrl.onFinishChange((fps) => {
  console.log(fps);
  if (interval) {
    clearInterval(interval);
  }
  interval = setInterval(draw, 1000 / fps);
});
