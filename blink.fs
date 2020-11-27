\ blink.fs blinks the LED on PC13 on an STM32F103C8.

forgetram
compiletoram

$40011000 constant GPIOC ( General purpose I/O ) 
GPIOC $4 + constant GPIOC-CRH ( Port configuration register high  GPIOn_CRL ) 
: ledInit ( -- )
    %01 20 lshift GPIOC-CRH bis! \ set PC13 mode to output, 10MHz max
    %11 22 lshift GPIOC-CRH bic! \ configure PC13 to output push-pull
;

GPIOC $10 + constant GPIOC-BSRR ( Port bit set/reset register  GPIOn_BSRR ) 
: led ( 0/1 -- ) \ turn off/on LED on PC13 (active low)
    0= if
        1 13 lshift GPIOC-BSRR bis! \ turn on LED
    else
        1 13 16 + lshift GPIOC-BSRR bis! \ turn off LED
    then
;
compiletoram

\ main
ledInit

: dly 0 do i drop loop ;
: blink 
    cr ." Press <enter> to quit"
    begin
        1 led 200000 dly
        0 led 200000 dly
        key?
    until
;

blink
