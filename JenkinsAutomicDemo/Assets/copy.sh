#!/bin/sh

count=$1

#耗时操作
for((i=1;i<=$count;i++));do
	echo $(expr $i \* 4);
done