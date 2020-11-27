\ blink.fs blinks the LED on PC13 on an STM32F103C8.

forgetram
compiletoram

#require led.fs

compiletoram

\ main
ledInit

: dly 0 do i drop loop ;

\ Blink blinks the LED on PC13.
: Blink 
    cr ." Press <enter> to quit"
    begin
        1 led 200000 dly
        0 led 200000 dly
        key?
    until
;

Blink

