#!/bin/bash

if [ "$1" == "-a" ];then
        echo $2 $3 >> tel.dat
fi
if [ "$1" == "-l" ];then
        echo cat tel.dat
fi
