# Package Validation

Validation project:

`C:/Repositories/Deucarian/Encounters-TestProject`

Unity version:

`6000.3.5f1`

## Local File References

The validation project consumes local packages through absolute file references:

- `com.deucarian.gameplay-foundation`
- `com.deucarian.persistence`
- `com.deucarian.progression`
- `com.deucarian.combat`
- `com.deucarian.encounters`

The Encounters runtime assembly depends only on Gameplay Foundation. The other packages are referenced only by the external compatibility harness.

## Commands

Import:

```powershell
& 'C:\Program Files\Unity\Hub\Editor\6000.3.5f1\Editor\Unity.exe' -batchmode -quit -projectPath 'C:\Repositories\Deucarian\Encounters-TestProject' -logFile 'C:\Repositories\Deucarian\Encounters-TestProject-import-5.log'
```

Batch tests:

```powershell
& 'C:\Program Files\Unity\Hub\Editor\6000.3.5f1\Editor\Unity.exe' -batchmode -projectPath 'C:\Repositories\Deucarian\Encounters-TestProject' -executeMethod BatchEditModeTestRunner.Run -batchTestResults 'C:\Repositories\Deucarian\Encounters-TestProject-batch-2.txt' -logFile 'C:\Repositories\Deucarian\Encounters-TestProject-batch-2.log'
```

Repeat:

```powershell
& 'C:\Program Files\Unity\Hub\Editor\6000.3.5f1\Editor\Unity.exe' -batchmode -projectPath 'C:\Repositories\Deucarian\Encounters-TestProject' -executeMethod BatchEditModeTestRunner.Run -batchTestResults 'C:\Repositories\Deucarian\Encounters-TestProject-batch-repeat.txt' -logFile 'C:\Repositories\Deucarian\Encounters-TestProject-batch-repeat.log'
```

## Results

- Import: passed, return code 0, no compiler errors.
- Batch: `result=Passed; passCount=16; failCount=0; skipCount=0; duration=0,122`
- Repeat: `result=Passed; passCount=16; failCount=0; skipCount=0; duration=0,132`

## Durable Benchmark

Path:

`C:/Repositories/Deucarian/Encounters-TestProject/Logs/encounters-scheduler-benchmark-results.json`

Recorded results:

- 1,000 scheduled requests: 1,000 drained, 0.334 ms, 0 bytes allocated.
- 5,000 scheduled requests: 5,000 drained, 1.434 ms, 0 bytes allocated.
- 10,000 scheduled requests: 10,000 drained, 3.042 ms, 0 bytes allocated.

These are Unity EditMode Mono measurements, not IL2CPP/Burst/mobile claims.
