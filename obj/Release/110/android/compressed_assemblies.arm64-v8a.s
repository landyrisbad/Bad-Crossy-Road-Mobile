	.arch	armv8-a
	.file	"compressed_assemblies.arm64-v8a.arm64-v8a.s"
	.include	"compressed_assemblies.arm64-v8a-data.inc"

	.section	.data.compressed_assembly_descriptors,"aw",@progbits
	.type	.L.compressed_assembly_descriptors, @object
	.p2align	3
.L.compressed_assembly_descriptors:
	/* 0: Java.Interop.dll */
	/* uncompressed_file_size */
	.word	162304
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_0

	/* 1: Mono.Android.dll */
	/* uncompressed_file_size */
	.word	1122816
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_1

	/* 2: Mono.Security.dll */
	/* uncompressed_file_size */
	.word	109568
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_2

	/* 3: MonoGame.Framework.dll */
	/* uncompressed_file_size */
	.word	1079296
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_3

	/* 4: Shit Crossy Road.dll */
	/* uncompressed_file_size */
	.word	19456
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_4

	/* 5: System.Core.dll */
	/* uncompressed_file_size */
	.word	58368
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_5

	/* 6: System.Drawing.Common.dll */
	/* uncompressed_file_size */
	.word	9216
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_6

	/* 7: System.Net.Http.dll */
	/* uncompressed_file_size */
	.word	212992
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_7

	/* 8: System.Numerics.dll */
	/* uncompressed_file_size */
	.word	25600
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_8

	/* 9: System.Runtime.Serialization.dll */
	/* uncompressed_file_size */
	.word	5632
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_9

	/* 10: System.dll */
	/* uncompressed_file_size */
	.word	580096
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_10

	/* 11: mscorlib.dll */
	/* uncompressed_file_size */
	.word	1963520
	/* loaded */
	.byte	0
	/* data */
	.zero	3
	.xword	compressed_assembly_data_11

	.size	.L.compressed_assembly_descriptors, 192
	.section	.data.compressed_assemblies,"aw",@progbits
	.type	compressed_assemblies, @object
	.p2align	3
	.global	compressed_assemblies
compressed_assemblies:
	/* count */
	.word	12
	/* descriptors */
	.zero	4
	.xword	.L.compressed_assembly_descriptors
	.size	compressed_assemblies, 16
