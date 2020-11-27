\ led.fs provides functions to drive the LED on PC13

#require gpio.fs

: ledInit ( -- )
    %01 20 lshift GPIOC-CRH bis! \ set PC13 mode to output, 10MHz max
    %11 22 lshift GPIOC-CRH bic! \ configure PC13 to output push-pull
;

: led ( 0/1 -- ) \ turn off/on LED on PC13 (active low)
    0= if
        1 13 lshift GPIOC-BSRR bis! \ turn on LED
    else
        1 13 16 + lshift GPIOC-BSRR bis! \ turn off LED
    then
;
