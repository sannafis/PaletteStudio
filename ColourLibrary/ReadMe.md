# Palette Studio Colour Library
(Work in Progress...)

This library consists of methods and utilities related to colours that will be used throughout the project (API and Client). 

## Colour Methods

<details>
  <summary>Convert to RGB Colour Code</summary>
    
  ```public static RGB ToRGBFromHex(string hex)```
  </details>

<details>
  <summary>Convert to Hex Colour Code</summary>
    
  ```public static string ToHexFromRGB(RGB rgb)```
  </details>

<details>
  <summary>Convert to HSV Colour Code</summary>
    
  ```public static HSV ToHSVFromRGB(RGB rgb)``` <br>
  ```public static HSV ToHSVFromHex(string hex)```
  </details>

<details>
  <summary>Calculate a Colour's Luminance</summary>
    
  ```public static double Luminance(RGB rgb)```
  </details>

<details>
  <summary>Calculate Cobtrast Ratio Between 2 Colours</summary>
    
  ```public static double ContrastRatio(RGB rgb1, RGB rgb2, out string ratio)``` <br>
  ```public static double ContrastRatio(RGB rgb1, RGB rgb2)``` <br>
  ```public static double ContrastRatio(string hex, string hex, out string ratio)``` <br>
  ```public static double ContrastRatio(string hex, string hex)```
  </details>

<details>
  <summary>WCAG Rating</summary>
    
  WCAG Rating (Regular Text): <br>
  ```public static string RegularTextRating(double contrast)``` <br>
  WCAG Rating (Large Text): <br>
  ```public static string LargeTextRating(double contrast)```
  </details>

## Other Classes
<details>
  <summary>HSV</summary>
  
  ```
  - h : int
  - s : int
  - v : int
  + H : int [ Min = 0, Max = 360 ]
  + S : int [ Min = 0, Max = 100 ]
  + V : int [ Min = 0, Max = 100 ]
  + ToString() : string
  ```
  </details>

<details>
  <summary>RGB</summary>
  
  ```
  - r : int
  - g : int
  - b : int
  + R : int [ Min = 0, Max = 255 ]
  + G : int [ Min = 0, Max = 255 ]
  + B : int [ Min = 0, Max = 255 ]
  + ToString() : string
  ```
  </details>

<details>
  <summary>WCAG</summary>
  
  ```
  + RegularTextAA : double = 4.50
  + RegularTextAAA : double = 7.00
  + LargeTextAA : double = 3.10
  + LargeTextAAA : double = 4.50
  ```
  </details>
